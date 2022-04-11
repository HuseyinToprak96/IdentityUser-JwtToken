using AutoMapper;
using AutoMapper.Internal.Mappers;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisLayer.Services
{
   public class UserService:Service<User>,IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper,UserManager<User> userManager) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _UserRepository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<UserDto>> CreateUserAsync(UserSignUpDto userSignUpDto)
        {
            var user = new User { Email = userSignUpDto.Email };
            var result = await _userManager.CreateAsync(user, userSignUpDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<UserDto>.Fail(new ErrorDto(errors, true), 400);

            }
            return Response<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<Response<UserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user==null)
            {
                return Response<UserDto>.Fail("Username not found",404,true);
            }
            return Response<UserDto>.Success(_mapper.Map<UserDto>(user), 200);
        }

        public async Task<string> LoginUser(string Email, string password)=> await _UserRepository.LoginUser(Email,password);
       
        public async Task<List<BusinessDto>> userBusinessGet(string id)
        {
            var userBusiness = await _UserRepository.UsergetByIdWithBusinesses(id);
            var BusinessesDto = _mapper.Map<List<BusinessDto>>(userBusiness);
            return BusinessesDto;
        }

        public async Task<UserInvitationsDto> UserbyIdWithInvitation(string id)
        {
            var userInvitation = await _UserRepository.UserbyIdWithInvitation(id);
            var userInvitationDto = _mapper.Map<UserInvitationsDto>(userInvitation);
            return userInvitationDto;
        }

        //public async Task<UserSubstribersDto> UserbyIdWithSubstriber(int id)
        //{
        //    var userSubstriber = await _UserRepository.UserbyIdWithSubstribers(id);
        //    var userSubstriberDto = _mapper.Map<UserSubstribersDto>(userSubstriber);
        //    return userSubstriberDto;
        //}
    }
}
