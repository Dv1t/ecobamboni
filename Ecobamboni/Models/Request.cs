using System;
using System.Collections.Generic;

namespace Ecobamboni.Models
{
    public class Request
    {
        public List<Container> Containers;
        public readonly DateTime RequestBirthday;

        public Request(List<Container>containers)
        {
            Containers = containers;
            RequestBirthday = System.DateTime.UtcNow;
        }
    }
}