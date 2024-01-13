using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    [Table("SearchHistory")]
    public class SearchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SearchID { get; set; }
        [StringLength(30)]
        [ForeignKey("User")]
        public string UserName { get; set; }
        [StringLength(50)]
        public string SearchQuery { get; set; }

        public virtual User?User { get; set; }

    }
}
