using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MY_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdWithBusiness()
        {
            var users = await _service.userBusinessGet("1");
            var UsersDto = _mapper.Map<List<BusinessDto>>(users);
            return Ok(Response<List<BusinessDto>>.Success(UsersDto, 200));

        }
       

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            var user = await _service.userBusinessGet(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(Response<UserDto>.Success(userDto, 200));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserSignUpDto userSignUpDto)
        {
            // var user = _mapper.Map<User>(userDto);
            //await _service.AddAsync(user);
            var result = await _service.CreateUserAsync(userSignUpDto);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }
        [Authorize]//Bu işlem bir token gerektirdiğinden dolayı yazılmak zorundadır.Direk istekte bulunulmaması için
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var result = await _service.GetUserByNameAsync(HttpContext.User.Identity.Name);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _service.UpdateAsync(user);
            return Ok(Response<NoDataDto>.Success(201));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(user);
            return Ok(Response<NoDataDto>.Success(202));
        }

    }
}
