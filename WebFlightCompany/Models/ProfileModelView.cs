using System.ComponentModel.DataAnnotations;

namespace WebFlightCompany.Models

{
    public class ProfileViewModel
    {
        private string? _firstName;
        private string? _lastName;
        private string? _email;


        [Required]
        [Display(Name = "First Name")]
        public string? Name { get { return _firstName; } set { _firstName = value; } }

        [Required]
        [Display(Name = "Last Name")]
        public string? SecondName { get { return _lastName; } set { _lastName = value; } }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get { return _email; } set { _email = value; } }

    }
}
