using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public interface IRentPropertRepo
    {

        Task<List<RentProperty>> GetAllProperty();

        Task<RentProperty>GetPropertyById(int PropertyId);

        Task InsertRentProperty(RentProperty property); 

        Task UpdateRentProperty(int  PropertyId, RentProperty property);

        Task DeleteRentProperty(int PropertyId);

    }
}
