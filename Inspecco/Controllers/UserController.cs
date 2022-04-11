
using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using DataLayer.Datas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspecco.Controllers
{
    public class UserController : Controller
    {
        //private readonly IUserService _service;
        //private readonly IMapper _mapper;
        public UserController()
        {
       //     _service = service;
            //_mapper = mapper;

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
           // string id = await _service.LoginUser(userName, password);
            //if (id!="")
              //  HttpContext.Session.SetString("ID", id);
            //else
            //{
             //   TempData["Hata"] = "Hatalı kullanıcı adı veya şifre";
                return RedirectToAction("Login");
            //}
            //return RedirectToAction("../Page/Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult SignUp(UserDto userDto)
        {
          //  var user = _mapper.Map<User>(userDto);
           // await _service.AddAsync(user);
            return RedirectToAction("Login");
        }
        public IActionResult MyBusinesses()
        {
            // int id =Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            //var users = await _service.userBusinessGet("1");
           // var UsersDto = _mapper.Map<List<BusinessDto>>(users);
            return View();
            // var BusinessesDto = _mapper.Map<List<Business>>(Businesses);

        }
    }
}
