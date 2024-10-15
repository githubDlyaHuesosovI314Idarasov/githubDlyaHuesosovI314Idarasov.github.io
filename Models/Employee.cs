using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Base;
using Models.Derived;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public sealed class Employee : Person
    {
        private Int32 _planeid;
        private String _position = null!;

        private Plane _plane = null!;

        public Int32 PlaneId { get { return _planeid; } set { _planeid = value; } }
        public String Position { get { return _position; } set { _position = value; } }

        [ValidateNever]
        public Plane Plane { get { return _plane; } set { _plane = value; } }

    }
}
