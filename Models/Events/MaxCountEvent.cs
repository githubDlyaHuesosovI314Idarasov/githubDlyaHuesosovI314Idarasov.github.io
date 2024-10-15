using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    internal class MaxCountEvent
    {
        private readonly String _msg;

        public MaxCountEvent(String msg)
        {
            _msg = msg;
        }

    }
}
