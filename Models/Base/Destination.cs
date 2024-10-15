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

        private String? _from;
        private String? _to;

        private TimeOnly _timeFrom;
        private TimeOnly _timeTo;
        

        public String? From { get { return _from; } set { _from = value; } }
        public String? To { get { return _to; } set { _to = value; } }
        public TimeOnly TimeFrom { get { return _timeFrom; } set { _timeFrom = value; } }
        public TimeOnly TimeTo { get { return _timeTo; } set { _timeTo = value; } }

    }
}
