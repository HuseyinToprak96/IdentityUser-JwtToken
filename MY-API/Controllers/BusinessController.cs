using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _service;
        private readonly IService<Invitation> _InvitationService;

        private readonly IMapper _mapper;
        public BusinessController(IBusinessService service, IService<Invitation> InvitationService, IMapper mapper = null)
        {
            _service = service;
            _mapper = mapper;
            _InvitationService = InvitationService;
        }
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var businesses = await _service.GetAllAsync();
           var businessDto= _mapper.Map<List<BusinessDto>>(businesses);
           return Ok(businessDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            var userDto = _mapper.Map<BusinessDto>(user);
            return Ok(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BusinessDto businessDto)
        {
            var business = _mapper.Map<Business>(businessDto);
           await _service.AddAsync(business);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Business business)
        {
            await _service.UpdateAsync(business);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           var business= await _service.GetByIdAsync(id);
            await _service.DeleteAsync(business);
            return Ok();
        }
    }
}
