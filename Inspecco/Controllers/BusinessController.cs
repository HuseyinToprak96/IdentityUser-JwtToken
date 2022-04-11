using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces.Service;
using CoreLayer.ViewModels;
using DataLayer.Datas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspecco.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly IService<Invitation> _InvitationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public BusinessController(IBusinessService businessService, IMapper mapper, IService<Invitation> ınvitationService, IUserService userService)
        {
            _businessService = businessService;
            _mapper = mapper;
            _InvitationService = ınvitationService;
            _userService = userService;
        }
        public async Task<IActionResult> List()
        {
            return View( await _businessService.GetAllAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BusinessDto businessDto)
        {
            businessDto.UserId = "1";
            var business = _mapper.Map<Business>(businessDto);
           await _businessService.AddAsync(business);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var business = await _businessService.GetByIdAsync(id);
           await _businessService.DeleteAsync(business);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Detail(int id)
        {
            BusinessDetai businessDetai = new BusinessDetai();
            businessDetai.business =await _businessService.GetByIdAsync(id);
          //  businessDetai.user = await _userService.u(businessDetai.business.UserId);
            var invitations=await _InvitationService.GetAllAsync();
            businessDetai.Invitations = invitations.Where(x => x.BusinessId == id&&x.IsTrue==true).ToList();
            businessDetai.Users = (List<User>)await _userService.GetAllAsync();
            //var businessDetail = await _businessService.BusinessGetByIdwithUsers(id);
            return View(businessDetai);
        }
    }
}
