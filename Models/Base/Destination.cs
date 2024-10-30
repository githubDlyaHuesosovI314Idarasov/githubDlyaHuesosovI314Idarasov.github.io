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

        private DateTime _dateTimeFrom;
        private DateTime _dateTimeTo;


        public String? CountryFrom { get { return _countryFrom; } set { _countryFrom = value; } }
        public String? CountryTo { get { return _countryTo; } set { _countryTo = value; } }
        public String? CityFrom { get { return _cityFrom; } set { _cityFrom = value; } }
        public String? CityTo { get { return _cityTo; } set { _cityTo = value; } }
        public DateTime DateTimeFrom { get { return _dateTimeFrom; } set { _dateTimeFrom = value; } }
        public DateTime DateTimeTo { get { return _dateTimeTo; } set { _dateTimeTo = value; } }
        

    }
}
