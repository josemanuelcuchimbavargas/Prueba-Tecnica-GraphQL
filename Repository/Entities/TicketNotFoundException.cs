using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class TicketNotFoundException : Exception
    {
        public int id { get; set; }
    }
}
