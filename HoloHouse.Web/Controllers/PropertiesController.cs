using System.Linq;
using System.Threading.Tasks;
using HoloHouse.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoloHouse.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class PropertiesController : Controller
    {
        private readonly DataContext _dataContext;

        public PropertiesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.PropertyImages)
                .Include(p => p.Contracts)
                .Include(p => p.Owner)
                .ThenInclude(o => o.User));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _dataContext.Properties
                .Include(o => o.Owner)
                .ThenInclude(o => o.User)
                .Include(o => o.Contracts)
                .ThenInclude(c => c.Lessee)
                .ThenInclude(l => l.User)
                .Include(o => o.PropertyType)
                .Include(p => p.PropertyImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }
    }
}