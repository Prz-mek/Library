using System.ComponentModel.DataAnnotations;

namespace Library.WebApp.Models.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana...")]
        [Display(Name = "Nazwa Użytkownika")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane...")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
