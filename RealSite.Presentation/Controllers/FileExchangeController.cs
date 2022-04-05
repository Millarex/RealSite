using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace RealSite.Presentation.Controllers
{
    public class FileExchangeController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        public FileExchangeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            var files = Directory.GetFiles(_appEnvironment.WebRootPath + "/FileExchange/");

            string[] filesNameList = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                filesNameList[i] = Path.GetFileName(files[i]);
            }

            return View(filesNameList);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFileCollection uploads)
        {
            if (ModelState.IsValid)
            {
                foreach (var uploadedFile in uploads)
                {
                    string path = "/FileExchange/" + uploadedFile.FileName;
                    if (!Directory.Exists("_appEnvironment.WebRootPath" + "/ FileExchange / "))
                    {
                        Directory.CreateDirectory("_appEnvironment.WebRootPath" + "/ FileExchange / ");
                    }
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                int fileNumber = id.Value;
                var files = Directory.GetFiles(_appEnvironment.WebRootPath + "/FileExchange/");
                var path = Path.GetFileName(files[fileNumber]);
                if (System.IO.File.Exists(_appEnvironment.WebRootPath + "/FileExchange/" + path))
                    System.IO.File.Delete(_appEnvironment.WebRootPath + "/FileExchange/" + path);

                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
