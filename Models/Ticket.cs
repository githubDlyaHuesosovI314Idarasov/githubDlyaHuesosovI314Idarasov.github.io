using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public sealed class Ticket : Destination
    {
        private Int32 _passengerId;
        private String _userId;
        private Boolean _isExpired;

        private Passenger _passenger = null!;


        public Int32 PassengerId { get { return _passengerId; } set { _passengerId = value; } }
        public String UserId { get { return _userId; } set { _userId = value; } }
        public Boolean IsExpired { get { return _isExpired; } set { _isExpired = value; } }

        [ValidateNever]
        public Passenger Passenger { get { return _passenger; } set { _passenger = value; } }
    }
}
