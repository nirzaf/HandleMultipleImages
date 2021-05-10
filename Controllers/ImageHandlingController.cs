using HandleMultipleImages.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HandleMultipleImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageHandlingController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        [HttpPost("api/ImageUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files, List<Image> images)
        {
            ArrayList imageList = new();
            var filePaths = new List<string>();
            int i = 0;
            foreach (var img in images)
            {
                    imageList.Add(images);   
                    var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, img.ImageName);
                    
                    //Image manipulation part any third party plugin or libraries can be used here 
                    img.Effect1 = true ;
                    img.Effect2 = false;
                    img.Effect3 = true;
                    img.Radius = 75;
                    img.Size = 100;

                    if (ImageValidators.IsExtensionValid(img.ImageName.ToString()))
                    {
                        filePaths.Add(filePath);
                        var fileNameWithPath = string.Concat(filePath, "\\", img.ImageName);
                        using var stream = new FileStream(fileNameWithPath, FileMode.Create);
                        imageList.Add(img);
                        await files[i].CopyToAsync(stream);
                    }
                i++;
            }
            // process uploaded files
            return Ok(new { count = files.Count, filePaths , imageList });
        }
    }


    public static class ImageValidators
    {
        public static bool IsExtensionValid(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            return string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
    }
}
