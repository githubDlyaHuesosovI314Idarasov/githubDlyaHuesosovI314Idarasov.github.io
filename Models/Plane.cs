using Models.Base;
using Models.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Models
{
    public sealed class Plane : Destination
    {
        private String _model;
        private Int32 _maxPassengerCount;
        private Int32 _destinationId;


        private IEnumerable<Passenger> _passengers = null!;
        private IEnumerable<Employee> _employees = null!;


        public String Model { get { return _model; } set { _model = value; } }
        public Int32 MaxPassengerCount { get { return _maxPassengerCount; } set { _maxPassengerCount = value; } }


        public IEnumerable<Employee> Employees { get { return _employees; } set { _employees = value; } }
        public IEnumerable<Passenger> Passengers { get { return _passengers; } set { _passengers = value; } }

    }
}
