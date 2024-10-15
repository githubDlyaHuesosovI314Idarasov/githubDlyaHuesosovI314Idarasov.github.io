using System.ComponentModel.DataAnnotations;

namespace WebFlightCompany.Models

{
    public class LoginViewModel : AccountBase
    {
        private bool _rememberMe;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } // { get { return _rememberMe; } set { _rememberMe = value; } }

    }
}
