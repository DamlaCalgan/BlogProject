using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DamlaProje.Blog.Business.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DamlaProje.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public ImagesController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogImageByIdAsync(int id) 
        {
            var blog = await _blogService.FindByIdAsync(id);
            if (string.IsNullOrWhiteSpace(blog.ImagePath))
                return NotFound("resim yok");
            return File($"/img/{blog.ImagePath}","image/jpeg");
        }
    }
}