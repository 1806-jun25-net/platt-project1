using MainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Mapper
    {

        public static User Map(WebApp.Models.UserWeb userweb) => new User
        {
            FirstName = userweb.FirstName,
            LastName = userweb.LastName,
            defStore = userweb.defStore
          
        };

    }
}
