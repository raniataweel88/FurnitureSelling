using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FurnitureSelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgesController1 : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<string> Imges(IFormFile file)
        {
            string pathImgFloder = Path.Combine(Directory.GetCurrentDirectory(),"Images");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please enter a vaild file");
            }
            string imgPath = Guid.NewGuid().ToString()+" "+ file.FileName;
            using (var filestream = new FileStream(Path.Combine(pathImgFloder, imgPath), FileMode.Create))
            {
                //load file to Memory
                await file.CopyToAsync(filestream);

                return imgPath;
            }
        }
    }
}
