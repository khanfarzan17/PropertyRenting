using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [StringLength(30)]
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must contain atleast 8 characters and maximum 30 ")]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string Role { get; set; }


        public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public virtual ICollection<SearchHistory> SearchHistorys { get; set; } = new HashSet<SearchHistory>();
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<RentProperty> RentProperties { get; set; } = new HashSet<RentProperty>();
    }
}
