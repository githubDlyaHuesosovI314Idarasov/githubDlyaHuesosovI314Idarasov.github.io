using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Base;
using Models.Derived;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public sealed class Passenger : Person
    {
        private Int32 _planeId;

        private Plane _plane = null!;
        private IEnumerable<Ticket> _tickets = null!;

        public Int32 PlaneId { get { return _planeId; } set { _planeId = value; } }

        [ValidateNever]
        public Plane Plane { get { return _plane; } set { _plane = value; } }
        [ValidateNever]
        public IEnumerable<Ticket> Tickets { get { return _tickets; } set { _tickets = value; } }

        


    }
}
