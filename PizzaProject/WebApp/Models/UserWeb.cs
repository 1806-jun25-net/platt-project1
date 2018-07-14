using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UserWeb
    {
        [Required]
        public string FirstName { get; set; } = "Bob";
        [Required]
        public string LastName { get; set; } = "Ross";
       
        public int UserID { get; set; }

        [Required]
        public string defStore { get; set; }

        [Required]
        public List<SelectListItem> AddressEnumerable = new List<SelectListItem>
       {
           new SelectListItem {Value = "Herndon", Text = "Herndon"},
           new SelectListItem {Value = "Reston", Text = "Reston"},
           
       };
    }
}
