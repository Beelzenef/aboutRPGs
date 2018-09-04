using System;

namespace aboutRPGs.Models {
    public class Partida {
        public Guid id {get; set;}
        [Required]
        public String title {get; set;}
        [Required]
        public String game {get; set;}
        public DateTimeOffset? meet { get; set;}
    }
}