using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entitys
{
   public class Business
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public User user { get; set; }//kurucu builder
        public List<Invitation> Invitations { get; set; }
    }
}
