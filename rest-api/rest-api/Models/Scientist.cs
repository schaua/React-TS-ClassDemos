using System;
using System.ComponentModel.DataAnnotations;

namespace rest_api.Models
{
    public class Scientist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageId { get; set; }

        [Required]
        public string Field { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }
    }
}
