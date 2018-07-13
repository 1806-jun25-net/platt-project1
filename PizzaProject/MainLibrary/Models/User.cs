using System;
using System.Collections.Generic;
using System.IO;
using MainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PS = DBContext.Models;
using DBContext.Models;

namespace MainLibrary.Models
{
    public class User
    {

        


        public string FirstName { get; set; } = "Bob";
        public string LastName { get; set; } = "Ross";
        public int UserID { get; set; }

    }
}
