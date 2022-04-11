using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisLayer.Map
{
   public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>//İstediğim zaman memory e yüklenmesi için Lazy kullandık
      {
          var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
          return config.CreateMapper();
      });
        public static IMapper Mapper => lazy.Value;
        }
}
