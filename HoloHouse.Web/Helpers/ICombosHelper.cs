using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HoloHouse.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPropertyTypes();
    }
}