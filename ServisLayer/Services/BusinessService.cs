using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisLayer.Services
{
   public class BusinessService:Service<Business>, IBusinessService
    {
        private readonly IBusinessRepository _UserRepository;
        private readonly IMapper _mapper;
        public BusinessService(IBusinessRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _UserRepository = repository;
            _mapper = mapper;
        }

        public async Task<BusinessInvitationsDto> BusinessGetByIdwithUsers(int id)
        {
        var businesses= await _UserRepository.BusinessGetByIdwithInvitations(id);
        var businessDto = _mapper.Map<BusinessInvitationsDto>(businesses);
            return businessDto;
        }
    }
}
