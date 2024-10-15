using System.ComponentModel.DataAnnotations;

namespace WebFlightCompany.Models

{
    public class AccountBase
    {
        private string _email;
        private string _password;

        [Required]
        [EmailAddress]
        public string Email { get; set; } // { get { return _email; } set { _email = value; } }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } // { get { return _password; } set { _password = value; } }
    }
}
