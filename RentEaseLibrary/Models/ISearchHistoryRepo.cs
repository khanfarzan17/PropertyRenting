using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public interface ISearchHistoryRepo
    {

        Task InsertSearchHistory(SearchHistory item);
        Task<List<RentProperty>> SearchRentProperty(string SearchQuery);

        Task<List<string>> OldSearch(string UserName);


    }
}
