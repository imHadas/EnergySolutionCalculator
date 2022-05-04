using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnergySolutionCalculator.Web.Models
{
    public enum Role
    {
        Administrator,
        User
    }

    public class LoginViewModel
    {
        [DisplayName("Felhasználónév")] 
        public string UserName { get; set; } = null!;
        [DisplayName("Jelszó")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
    public class RegisterViewModel
    {

        [DisplayName("Felhasználónév")]
        public string UserName { get; set; } = null!;
        [DisplayName("Jelszó")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DisplayName("Jelszó megerősítése")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Jelszavak nem egyeznek")]
        public string ConfirmPassword { get; set; } = null!;
        [DisplayName("Role")]
        public Role RoleType { get; set; }
        
    }
}
