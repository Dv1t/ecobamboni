using System.Data.Entity;

namespace Ecobamboni.Models
{
    public class ContainerContext :DbContext
    {
        public DbSet<Container> Containers{get;set;}
    }
}