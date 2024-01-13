using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public interface IFavoriteRepo
    {

        Task<List<RentProperty>> GetAllFavoriteByUserName(string userName);

        Task InsertFavorites(Favorite favorite);

        Task DeleteFavorites(Favorite favorite);


    }
}
