using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        [StringLength(30)]
        [ForeignKey("User")]
        public string? UserName { get; set; }
        [ForeignKey("RentProperty")]
        public int? PropertyId { get; set; }

        public Status BookingStatus { get; set; }
        [Required]
        public DateTime CheackedInDate { get; set; }
        [Required]
        public DateTime CheackedOutDate { get; set; }

        public virtual User? User { get; set; }

        public virtual RentProperty? RentProperty { get; set; }




    }

    public enum Status
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
