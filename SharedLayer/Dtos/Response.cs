using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLayer.Dtos
{
   public class Response<T> where T:class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public ErrorDto Error { get; set; }
        [JsonIgnore]//Dış dünyaya kapattık. Apiden istekte bulunanlar erişemez..
        public bool IsSuccess { get; set; }
        public static Response<T> Success(T data, int statusCode)//Eklenen data için
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccess=true };
        }
        public static Response<T> Success(int statusCode)//silinen ve güncellenen data için
        {
            return new Response<T> {Data=default, StatusCode = statusCode, IsSuccess=true };
        }
        public static Response<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccess=false };
        }
        public static Response<T> Fail(string errorMessage, int statusCode,bool isShow )
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccess=false };
        }
    }
}
