using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.DAL.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recevers { get; set; }
        //[Required(ErrorMessage ="Email requred")]
        //[MinLength(5)]
        //[DataType(DataType.Em//public string EmailName { get; set; }
    }
}
