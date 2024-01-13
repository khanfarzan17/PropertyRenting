using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    [Table("RentProperty")]
    public class RentProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PropertyId { get; set; }
        [StringLength(30)]
        [ForeignKey("User")]
        public string? UserName { get; set; }
        [StringLength(50)]
        [Required]
        public string PropertyName { get; set; }
        [StringLength(100)]
        [Required]
        public string Location { get; set; }
        [StringLength(10)]
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();


    }
}
