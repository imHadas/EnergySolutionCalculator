using EnergySolutionCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using EnergySolutionCalculator.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace EnergySolutionCalculator.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UploadController : Controller
    {
        private readonly ICalculatorService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public UploadController(ICalculatorService service, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ReadExcelViewModel vm)
        {
            if(vm.File is null)
            {
                ModelState.AddModelError("", "Hibás fájlfeltöltés");
                return View(vm);
            }
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(vm.File.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                vm.File.CopyTo(stream);
            }

            string conString = _configuration.GetConnectionString("ExcelConString");
            DataTable dt = new DataTable();
            conString = string.Format(conString, filePath);

            using (OleDbConnection connExcel = new OleDbConnection(conString))
            {
                using (OleDbCommand cmdExcel = new OleDbCommand())
                {
                    using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                    {
                        cmdExcel.Connection = connExcel;
                        
                        connExcel.Open();
                        DataTable dtExcelSchema;
                        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        connExcel.Close();

                        //Read Data from First Sheet.
                        connExcel.Open();
                        cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                        odaExcel.SelectCommand = cmdExcel;
                        odaExcel.Fill(dt);
                        connExcel.Close();
                    }
                }
            }
            
            foreach(DataRow dr in dt.Rows)
            {
                var inverter = new Inverter
                {
                    Name = dr["Name"].ToString(),
                    Size = Decimal.Parse(dr["Size"].ToString()),
                    Amps = dr["Amps"].ToString(),
                    MinNumberOfPanels = Int32.Parse(dr["MinNumberOfPanels"].ToString()),
                    MaxNumberOfPanels = Int32.Parse(dr["MaxNumberOfPanels"].ToString()),
                    PriceHuf = Decimal.Parse(dr["PriceHuf"].ToString())
                };
                var inv = _service.GetInverterByName(inverter.Name);
                if(inv is not null)
                {
                    inv.Size = inverter.Size;
                    inv.Amps = inverter.Amps;
                    inv.MinNumberOfPanels = inverter.MinNumberOfPanels;
                    inv.MaxNumberOfPanels = inverter.MaxNumberOfPanels;
                    inv.PriceHuf = inverter.PriceHuf;
                    var result = _service.UpdateInverter(inv);
                    if (!result)
                        return View(vm);
                }
                else
                    _service.AddInverter(inverter);
            }
            return RedirectToAction("Index", "Inverter");
        }
    }
}

        
