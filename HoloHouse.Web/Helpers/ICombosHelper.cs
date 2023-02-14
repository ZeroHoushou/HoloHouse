using System.Collections.Generic;
using System.Threading.Tasks;
using HoloHouse.Web.Data.Entities;
using HoloHouse.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HoloHouse.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPropertyTypes();
        IEnumerable<SelectListItem> GetComboLessees();
       
    }
}