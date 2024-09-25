using System.ComponentModel.DataAnnotations;
namespace TravelGuide.Entiteis.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [MaxLength(70)]
        public string LocationName { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
