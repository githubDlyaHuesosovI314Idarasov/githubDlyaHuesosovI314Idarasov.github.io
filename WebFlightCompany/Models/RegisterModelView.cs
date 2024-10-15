using System.ComponentModel.DataAnnotations;

namespace WebFlightCompany.Models

{
    public class RegisterViewModel : AccountBase
    {
        private string _name;
        private string _secondName;
        private int _age;
        private string _sex;
        private string _confirmPassword;

        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } //{ get { return _name; } set { _name = value; } }

        [Display(Name = nameof(SecondName))]
        [Required(ErrorMessage = "Second Name is required")]
        public string SecondName { get; set; } //{ get { return _secondName; } set { _secondName = value; } }
        
        [Display(Name = nameof(Age))]
        [Required(ErrorMessage = "Age is required")]
        [Range(1, 150, ErrorMessage = "Please enter a valid age")]
        public int Age { get; set; } // { get { return _age; } set { _age = value; } }
       
        [Display(Name = nameof(Sex))]
        [Required(ErrorMessage = "Sex is required")]
        public string Sex { get; set; } // { get { return _sex; } set { _sex = value; } }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } // { get { return _confirmPassword; } set { _confirmPassword = value; } }

    }
}
