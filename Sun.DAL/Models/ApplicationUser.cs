using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.DAL.Models
{
    public class ApplicationUser: IdentityUser
    {
        [MaxLength(60)]
        public string? Address { get; set; }
        [MaxLength(15)]
        [MinLength(10)]
        public string? Phone {  get; set; }
    }
}
