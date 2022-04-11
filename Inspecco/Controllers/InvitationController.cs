using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspecco.Controllers
{
    public class InvitationController : Controller
    {
        private readonly IService<Invitation> _service;
        private readonly IMapper _mapper;
        public InvitationController(IService<Invitation> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> Add(InvitationDto invitationDto)
        {
            var invitation = _mapper.Map<Invitation>(invitationDto);
            await _service.AddAsync(invitation);
            return RedirectToAction("/Business/Detail",invitation.BusinessId);
        }
    }
}
