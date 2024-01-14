using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public class EFFavoriteRepo : IFavoriteRepo

    {
       PropertyRentingDbContext ctx = new PropertyRentingDbContext();

        public async Task DeleteFavorites(Favorite favorite)
        {
            ctx.Favorite.Remove(favorite);
            await ctx.SaveChangesAsync();


        }

        public async Task<List<RentProperty>> GetAllFavoriteByUserName(string userName)
        {
            List<Favorite> properties = await (from f in ctx.Favorite where f.UserName == userName select f).ToListAsync();
            List<RentProperty> FavouriteProperty = new List<RentProperty>();
            foreach (Favorite f in properties)
            {

                int? x = f.PropertyID;

                RentProperty property = await (from n in ctx.RentProperties where n.PropertyId == x select n).FirstAsync();

                FavouriteProperty.Add(property);

            }
            await ctx.SaveChangesAsync();
            return FavouriteProperty;
        }

        public async Task InsertFavorites(Favorite favorite)
        {
            ctx.Favorite.Add(favorite);
            await ctx.SaveChangesAsync();
        }
    }
}
