using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entitys
{
   public class Invitation
    {
        public int InvitationId { get; set; }

        public int? BusinessId { get; set; }
        public bool? IsTrue { get; set; }//false ise islem yapılmadı true ise kabul etti.
       [ForeignKey("user")]
        public string userId { get; set; }
        public User user { get; set; }
        public Business business { get; set; }
    }
}
