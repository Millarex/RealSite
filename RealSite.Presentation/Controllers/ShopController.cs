using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealSite.Infrastructure.Persistance;
using RealSite.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    public class ShopController : Controller
    {
        ApplicationContext db;
        public ShopController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var temp = await db.Machines.Include(u => u.ManufactureModel).Include(p => p.Photos).ToListAsync();
            return View(temp);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id != null)
            {
                var machine = await db.Machines.Include(u => u.ManufactureModel).Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);

                if (machine != null)
                {
                    var mv = new MachineEditorViewModel
                    {
                        Id = machine.Id,
                        Name = machine.Name,
                        ModelInfo = machine.ModelInfo,
                        ManufactureModelId = machine.ManufactureModelId,
                        Price = machine.Price,
                        Manufactures = await db.Manufactures.ToListAsync(),
                        Photos = machine.Photos
                    };
                    return View(mv);
                }
            }
            return NotFound();
        }
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
