using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UpdateTicketInput
    {
        public int id { get; set; }
        public string user { get; set; }        
        public string status { get; set; }
    }
}
