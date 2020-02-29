using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ecobamboni.Models
{
    public class ContainerDbInitializer:DropCreateDatabaseAlways<ContainerContext>
    {
        protected override void Seed(ContainerContext context)
        {
            context.Containers.Add(new Container {Location = "ITMO",Fullness =0 });

            base.Seed(context);
        }

    }
}