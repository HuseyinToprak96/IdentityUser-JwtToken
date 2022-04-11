using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
   public class BusinessDto
    {
        public int? BusinessId { get; set; }
        public string BusinessName { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public string UserId { get; set; }
    }
}
