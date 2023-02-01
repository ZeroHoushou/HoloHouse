using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HoloHouse.Web.Data;
using HoloHouse.Web.Data.Entities;

namespace HoloHouse.Web.Views.Owners
{
    public class DetailsModel : PageModel
    {
        private readonly HoloHouse.Web.Data.DataContext _context;

        public DetailsModel(HoloHouse.Web.Data.DataContext context)
        {
            _context = context;
        }

        public Owner Owner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owner = await _context.Owners.FirstOrDefaultAsync(m => m.Id == id);

            if (Owner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
