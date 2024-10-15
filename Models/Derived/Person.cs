using Models.Base;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Derived
{
    public abstract class Person : EntityBase, IPerson
    {
        private String _name;
        private String _secondName;
        private String _sex;

        private Int32 _age;

        [MaxLength(35)]
        public String Name { get { return _name; } set { _name = value; } }
        [MaxLength(35)]
        public String SecondName { get { return _secondName; } set { _secondName = value; } }
        public Int32 Age { get { return _age; } set { _age = value; } }
        public String Sex { get { return _sex; } set { _sex = value; } }

    }
}
