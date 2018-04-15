using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public HelloWorldController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                string directoryPath = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        string fullPath = Path.Combine(directoryPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }


        /*
                public async Task<IActionResult> Upload(IFormFile file)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                    return RedirectToAction("Index");
                }
                 */
    }
}