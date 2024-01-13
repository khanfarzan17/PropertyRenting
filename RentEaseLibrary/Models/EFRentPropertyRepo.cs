using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public class EFRentPropertyRepo : IRentPropertRepo
    {

       PropertyRentingDbContext ctx = new PropertyRentingDbContext();


        public async Task DeleteRentProperty(int PropertyId)
        {
            RentProperty rentProperty= await GetPropertyById(PropertyId);
            ctx.RentProperties.Remove(rentProperty);
            ctx.SaveChanges();
        }

        public async Task<List<RentProperty>> GetAllProperts()
        {
            List<RentProperty> properties = await ctx.RentProperties.ToListAsync();
            return properties;
        }

        public async Task<RentProperty> GetPropertyById(int PropertyId)
        {
            try
            {
                RentProperty properties = await (from p in ctx.RentProperties where p.PropertyId == PropertyId select p).FirstAsync();
                return properties;

            }
            catch (Exception)
            {
                throw new Exception("No such Proprty Id is Found");
            }
        }

        public async Task InsertRentProperty(RentProperty property)
        {
            await ctx.RentProperties.AddAsync(property);
            await ctx.SaveChangesAsync();

        }

        public async Task UpdateRentProperty(int PropertyId, RentProperty property)
        {
            RentProperty property2update= await GetPropertyById(PropertyId);

            property2update.PropertyName= property.PropertyName;
            property2update.Location= property.Location;
            property2update.Type= property.Type;
            property2update.Price= property.Price;

            await ctx.SaveChangesAsync();
        }
    }
}
