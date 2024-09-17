using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Entiteis.Models
{
    public class WatchlistItem
    {
        [Key]
        public int WatchlistItemId { get; set; }

       // [ForeignKey("User")]
        //[ForeignKey(nameof(User))]
        //public int UserId { get; set; }

        public int ItemID { get; set; }

        [MaxLength(20)]
        public string ItemType { get; set; }

        //public User User { get; set; }

    }
}
