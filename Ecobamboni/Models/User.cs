using System.ComponentModel.DataAnnotations;

namespace Ecobamboni.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }


    }
}