using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Entiteis.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        //public int UserId { get; set; }
        public double Amount { get; set; }
        [MaxLength(50)]
        public string Currency { get; set; }
        [MaxLength(50)]
        public string Method { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; } 
    }
}
