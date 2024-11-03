using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.DAL.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = "mahmoudqtari5@gmail.com";
        public string SentEmail { get; set; }
        public decimal Phone { get; set; }
        public decimal NumberOfPeople { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}
