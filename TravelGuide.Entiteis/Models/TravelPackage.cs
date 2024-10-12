using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TravelGuide.Entiteis.Models
{
    public class TravelPackage
    {
        [Key]
        public int PackageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PackageName { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public Location? Destination { get; set; }

        public int DestinationId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; }  // Duration in days

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int MaxGuests { get; set; }

        public decimal? Rating { get; set; }

        public string PackageImage { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
