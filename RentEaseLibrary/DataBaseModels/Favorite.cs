using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RentEaseLibrary.Models
{
    [Table("Favorite")]
    [PrimaryKey("UserName", "PropertyID")]
    public class Favorite
    {
        [StringLength(30)]
        [ForeignKey("User")]
        public string? UserName { get; set; }

        [ForeignKey("RentProperty")]

        public int? PropertyID { get; set; }

        public virtual User? User { get; set; }

        public virtual RentProperty? Property { get; set; }



    }
}
