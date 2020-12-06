using AutoMapper;
using DamlaProje.Blog.Business.Interfaces;
using DamlaProje.Blog.Business.Tools.FacadeTool;
using DamlaProje.Blog.Business.Tools.LogTool;
using DamlaProje.Blog.DTO.DTOs.CategoryDtos;
using DamlaProje.Blog.Entities.Concrete;
using DamlaProje.Blog.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamlaProje.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
       
        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllSortedByIdAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValildModel]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValildModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id)
            {
                return BadRequest("geçeris id");
            }
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(await _categoryService.FindByIdAsync(id));
            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsCount() 
        {
           var categories= await _categoryService.GetAllWithCategoryBlogsAsync();
            List<CategoryWithBlogsCountDto> listCategory = new List<CategoryWithBlogsCountDto>();
            foreach (var category in categories)
            {
                CategoryWithBlogsCountDto dto = new CategoryWithBlogsCountDto();
                dto.CategoryName= category.Name;
                dto.CategoryId= category.Id;
                dto.BlogsCount = category.CategoryBlogs.Count;
                listCategory.Add(dto);
            }
            return Ok(listCategory);
        }

    }
}