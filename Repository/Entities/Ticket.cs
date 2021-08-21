using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Ticket
    {
        [Key]
        public int id { get; set; }        
        public string user { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }        
        public string status { get; set; }
    }
}
