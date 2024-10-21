using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    
    public class Destination : EntityBase
    {
        private String? _countryFrom;
        private String? _countryTo;
        private String? _cityFrom;
        private String? _cityTo;


        private TimeOnly _timeFrom;
        private TimeOnly _timeTo;
        private DateOnly _datefrom;
        private DateOnly _dateto;
       
        public String? CountryFrom { get { return _countryFrom; } set { _countryFrom = value; } }
        public String? CountryTo { get { return _countryTo; } set { _countryTo = value; } }
        public String? CityFrom { get { return _cityFrom; } set { _cityFrom = value; } }
        public String? CityTo { get { return _cityTo; } set { _cityTo = value; } }
        public TimeOnly TimeFrom { get { return _timeFrom; } set { _timeFrom = value; } }
        public TimeOnly TimeTo { get { return _timeTo; } set { _timeTo = value; } }
        public DateOnly DateFrom { get { return _datefrom; } set { _datefrom = value; } }
        public DateOnly DateTo { get { return _dateto; } set { _dateto = value; } }
        

    }
}
