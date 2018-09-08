using System;
using System.ComponentModel.DataAnnotations;

namespace aboutRPGs.Models
{
    public class Adventure
    {
        public Guid id { get; set; }
        [Required]
        public String title { get; set; }
        [Required]
        public String game { get; set; }
        public DateTimeOffset? meet { get; set; }
    }
}