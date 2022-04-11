using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
   public class InvitationDto
    {
        public int InvitationId { get; set; }
        public int BusinessId { get; set; }
        public bool IsTrue { get; set; }
        public int UserId { get; set; }
    }
}
