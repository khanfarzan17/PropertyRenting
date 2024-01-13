using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public interface IUserRepo
    {

        Task<List<User>> GetAllUser();

        Task<User>GetUserByUserName(string userName);

        Task InsertUser(User user); 

        Task DeleteUserByUserName(string userName);

        Task Login(User user);



    }
}
