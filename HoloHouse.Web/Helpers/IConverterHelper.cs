using System.Threading.Tasks;
using HoloHouse.Web.Models;
using HoloHouse.Web.Data.Entities;

namespace HoloHouse.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Property> ToPropertyAsync(PropertyViewModel model, bool isNew);

        PropertyViewModel ToPropertyViewModel(Property property);
    }
}