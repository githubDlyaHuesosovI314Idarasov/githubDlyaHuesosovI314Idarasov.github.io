using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Interfaces
{
    public interface IPerson
    {
        public String Name { get; set; }
        public String SecondName { get; set; }
        public Int32 Age { get; set; }  
        public enum Sex { Male = 0, Female = 1 };

    }
}
