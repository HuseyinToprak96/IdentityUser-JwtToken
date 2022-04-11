using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
   public class BusinessDetailDto:BusinessDto
    {
        public UserDto Builder { get; set; }
        public List<InvitationDto> InvitationDtos { get; set; }
        public List<UserDto> Substriders { get; set; }

    }
}
