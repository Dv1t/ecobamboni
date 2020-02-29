using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ecobamboni.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Users.Add(new User { Id = 1, Name = "Ivanov Ivan Ivanovich", Login = "admin", Password = "admin", Role = 1 });
            context.Users.Add(new User { Id = 2, Name = "Kozlov Ivan Ivanovich", Login = "qwerty", Password = "qwetry", Role = 2 });


            base.Seed(context);
        }
    }
}