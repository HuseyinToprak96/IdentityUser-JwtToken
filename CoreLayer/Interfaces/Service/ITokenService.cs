using CoreLayer.Configuration;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
   public interface ITokenService
    {
        TokenDto CreateToken(User user);
        ClientTokenDto CreateTokenByClient(Client client);//WEB VE MOBİL UYGULAMALAR İÇİN
    }
}
