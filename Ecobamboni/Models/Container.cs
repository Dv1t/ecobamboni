using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecobamboni.Models
{

    public class Container
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public int Fullness { get; set; }
        public string Owner { get; set; }
    }
}