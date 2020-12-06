using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DamlaProje.Blog.Business.Interfaces;
using DamlaProje.Blog.Business.Tools.JWTTool;
using DamlaProje.Blog.DTO.DTOs.AppUserDtos;
using DamlaProje.Blog.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DamlaProje.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }
        [HttpPost("[action]")]
        [ValildModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);
            if (user != null)
            {

                return Created("", _jwtService.GenerateJwt(user));
            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser() 
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);
            return Ok(new AppUserDto 
            {
                 Id = user.Id,
                 Name = user.Name,
                 SurName = user.SurName
            });
        }
    }
}