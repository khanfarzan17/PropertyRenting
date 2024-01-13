using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public class PropertyRentingDbContext:DbContext
    {

        public PropertyRentingDbContext()
        {
            
        }
       public PropertyRentingDbContext(DbContextOptions<PropertyRentingDbContext> options) : base(options) {
        
        }



        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Favorite> Favorite { get; set; }

        public virtual DbSet<RentProperty>RentProperties { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }    

        public virtual DbSet<SearchHistory> SearchHistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;database=PropertyRentingDb;Integrated Security=True");
        }
    }
}
