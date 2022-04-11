using CoreLayer.Dtos;
using SharedLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
   public interface IAuthenticationService
    {
        //Girilen bilgiler dogruysa Token Döndürmek için.
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        //1.Giriş işleminde kullanılacak 
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        //2.Clientler refreshToken ile beraber yeni token alabilir.
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        //3.RefreshToken ı sonlandırmak için kullanılır. Kullanıcı logout yaptıgında mesela.
        //RefreshToken çalındığında ihtiyac vardır.
        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
        //4.Client ile birlikte alınacak token işlemi için gereklidir.
    }
}
