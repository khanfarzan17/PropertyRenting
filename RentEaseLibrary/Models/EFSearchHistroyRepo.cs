using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public class EFSearchHistroyRepo:ISearchHistoryRepo
    {

        PropertyRentingDbContext ctx= new PropertyRentingDbContext();

        public async Task InsertSearchHistory(SearchHistory item)
        {
            ctx.SearchHistory.Add(item);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<string>> OldSearch(string UserName)
        {
            List<SearchHistory>searchHistory=await(from s in ctx.SearchHistory where s.UserName == UserName select s).ToListAsync();

            List<string> newSearch = new List<string>();
            foreach (SearchHistory f in searchHistory)
            {
                string x = f.SearchQuery;
                newSearch.Add(x);

            }
            return newSearch;
        }


        public async Task<List<RentProperty>> SearchRentProperty(string SearchQuery)
        {
            List<RentProperty> searchproperties = await ctx.RentProperties.Where(p => p.PropertyName.Contains(SearchQuery) || p.Location.Contains(SearchQuery)).ToListAsync();
            return searchproperties;
        }
    }
}
