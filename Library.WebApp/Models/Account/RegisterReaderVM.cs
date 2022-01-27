using System.ComponentModel.DataAnnotations;

namespace Library.WebApp.Models.Account
{
    public class RegisterReaderVM
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana...")]
        [Display(Name = "Nazwa Użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane...")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane...")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane...")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany...")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
