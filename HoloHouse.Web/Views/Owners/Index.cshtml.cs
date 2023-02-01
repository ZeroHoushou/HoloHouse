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
    public class IndexModel : PageModel
    {
        private readonly HoloHouse.Web.Data.DataContext _context;

        public IndexModel(HoloHouse.Web.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; }

        public async Task OnGetAsync()
        {
            Owner = await _context.Owners.ToListAsync();
        }
    }
}
