using System.ComponentModel.DataAnnotations;

namespace EnergySolutionCalculator.Web.Models
{
    public class ReadExcelViewModel
    {
        [Required(ErrorMessage = "Please select file")]

        [FileExt(Allow = ".xls,.xlsx", ErrorMessage = "Only excel file")]
        public IFormFile File { get; set; } = null!;
    }
}
