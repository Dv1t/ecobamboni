using System;
using System.Collections.Generic;

namespace Ecobamboni.Models
{
    public class Request
    {
        public List<Container> Containers;
        public readonly DateTime RequestBirthday;
        public readonly string Creator;

        public Request(List<Container>containers,string creator)
        {
            Containers = containers;
            Creator = creator;
            RequestBirthday = System.DateTime.UtcNow;
        }
    }
}