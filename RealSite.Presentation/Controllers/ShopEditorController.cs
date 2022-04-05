using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealSite.Persistance;
using RealSite.Presentation.ViewModels;
using System.IO;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{/*
    [Authorize(Roles = "Administrator,Moderator")]
    public class ShopEditorController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public ShopEditorController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var temp = await db.Machines.Include(u => u.ManufactureModel).Include(p => p.Photos).ToListAsync();
            return View(temp);
        }
        public async Task<IActionResult> Create()
        {
            var manufactures = await db.Manufactures.ToListAsync();
            MachineEditorViewModel vm = new MachineEditorViewModel { Manufactures = manufactures };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MachineEditorViewModel mv, IFormFileCollection uploads)
        {
            if (ModelState.IsValid)
            {
                if (uploads != null)
                {
                    var machine = new MachineModel
                    {
                        Name = mv.Name,
                        ModelInfo = mv.ModelInfo,
                        Price = mv.Price,
                        ManufactureModelId = mv.ManufactureModelId,
                        Photos = new System.Collections.Generic.List<ImageModel>()
                    };
                    foreach (var uploadedFile in uploads)
                    {

                        string path = "/ShopImages/" + uploadedFile.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        ImageModel image = new ImageModel { Name = uploadedFile.FileName, Path = path };
                        db.Images.Add(image);
                        machine.Photos.Add(image);
                    }
                    db.Machines.Add(machine);
                }
                else
                {
                    var machine = new MachineModel
                    {
                        Name = mv.Name,
                        ModelInfo = mv.ModelInfo,
                        Price = mv.Price,
                        ManufactureModelId = mv.ManufactureModelId
                    };
                    db.Machines.Add(machine);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mv);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                MachineModel machine = await db.Machines.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);

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
        [HttpPost]
        public async Task<IActionResult> Edit(MachineEditorViewModel mv, IFormFileCollection uploads)
        {
            if (ModelState.IsValid)
            {
                if (uploads != null)
                {
                    var machine = new MachineModel
                    {
                        Id = mv.Id,
                        Name = mv.Name,
                        ModelInfo = mv.ModelInfo,
                        ManufactureModelId = mv.ManufactureModelId,
                        Price = mv.Price,
                        Photos = mv.Photos
                    };
                    foreach (var uploadedFile in uploads)
                    {

                        string path = "/ShopImages/" + uploadedFile.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        ImageModel image = new ImageModel { Name = uploadedFile.FileName, Path = path };
                        db.Images.Add(image);
                        machine.Photos.Add(image);
                    }
                    db.Machines.Update(machine);
                }
                else
                {
                    var machine = new MachineModel
                    {
                        Id = mv.Id,
                        Name = mv.Name,
                        ModelInfo = mv.ModelInfo,
                        ManufactureModelId = mv.ManufactureModelId,
                        Price = mv.Price
                    };
                    db.Machines.Update(machine);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mv);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                MachineModel machine = await db.Machines.FirstOrDefaultAsync(p => p.Id == id);
                if (machine != null)
                    return View(machine);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                MachineModel machine = await db.Machines.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == id);
                foreach (var image in machine.Photos)
                {
                    if (System.IO.File.Exists(_appEnvironment.WebRootPath + image.Path))
                        System.IO.File.Delete(_appEnvironment.WebRootPath + image.Path);
                }
                db.Entry(machine).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("DeleteImage")]
        public async Task<IActionResult> ConfirmDeleteImage(int? id)
        {
            if (id != null)
            {
                ImageModel image = await db.Images.FirstOrDefaultAsync(p => p.ID == id);
                if (image != null)
                    return View(image);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id != null)
            {
                ImageModel image = await db.Images.FirstOrDefaultAsync(p => p.ID == id);
                if (image != null)
                {
                    if (System.IO.File.Exists(_appEnvironment.WebRootPath + image.Path))
                        System.IO.File.Delete(_appEnvironment.WebRootPath + image.Path);
                    db.Entry(image).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Edit", new { id = image.MachineModelId });
                }
                return NotFound();
            }
            return NotFound();
        }
    }*/
}
