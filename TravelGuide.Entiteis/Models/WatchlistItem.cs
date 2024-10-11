using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public class WatchlistItem
    {
        [Key]
        public int WatchlistItemId { get; set; }

        public string UserId { get; set; }

        public int ItemID { get; set; }

        [MaxLength(20)]
        public string ItemType { get; set; }

        public AppUser? User { get; set; }

    }
}
