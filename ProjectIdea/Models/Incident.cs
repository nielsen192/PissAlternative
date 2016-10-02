using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectIdea.Models
{
    public class Incident
    {
        // Is this id connected to the customer id via the same dbset?? prob not
        public int Id { get; set; }
        public DateTime Timestamp
        {
            set
        {
            var now = DateTime.Now;
        }
        }
        
    }
}