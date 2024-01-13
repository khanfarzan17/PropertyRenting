using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public class EFUserRepo : IUserRepo
    {
         PropertyRentingDbContext ctx= new PropertyRentingDbContext();
        public async Task DeleteUserByUserName(string userName)
        {
            User user =await GetUserByUserName(userName);
            ctx.Users.Remove(user);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUser()
        {
            List<User> users = await ctx.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            try
            {
                User user = await (from u in ctx.Users where u.UserName == userName select u).FirstAsync();
                if(user == null)
                {
                    throw  new InvalidOperationException("No such UserName is found ");
                    
                }
                return user;


            }
            catch (Exception ex )
            {
                throw new Exception("An error occurred while retrieving the user by UserName", ex);
            }
        }

        public async Task InsertUser(User user)
        {
           await ctx.Users.AddAsync(user);
            await ctx.SaveChangesAsync();
        }

        public Task Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
