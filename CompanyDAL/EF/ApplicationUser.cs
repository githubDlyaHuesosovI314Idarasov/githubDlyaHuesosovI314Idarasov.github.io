using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Areas.AspNet.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        private String _name;
        private String _secondName;
        private Int32 _age;
        private String _sex;


        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get { return _name; } set { _name = value; } }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String SecondName { get { return _secondName; } set { _secondName = value; } }

        [PersonalData]
        public Int32 Age { get { return _age; } set { _age = value; } }

        [PersonalData]
        [Column(TypeName = "nvarchar(30)")]
        public String Sex { get { return _sex; } set { _sex = value; } }

        
    }
}
