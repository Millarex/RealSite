using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealSite.Persistance;
using RealSite.Presentation.ViewModels;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    [Authorize(Roles = "Administrator,Moderator")]
    public class ManufactureController : Controller
    {
        private ApplicationContext db;
        public ManufactureController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Manufactures.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ManufactureViewModel mm)
        {
            if (ModelState.IsValid)
            {
                ManufactureModel model = new ManufactureModel { Name = mm.Name };
                db.Manufactures.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mm);
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ManufactureModel mm = await db.Manufactures.FirstOrDefaultAsync(p => p.ID == id);
                if (mm != null)
                    return View(mm);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ManufactureModel mm = new ManufactureModel { ID = id.Value };
                db.Entry(mm).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
