using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entitys
{
   public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        //public List<Substriber> Substribers { get; set; }
        public virtual List<Business> Businesses { get; set; }//Kurucusu olduğu Firmalar
        public virtual List<Invitation> Invitations { get; set; }//Abonelik içinde Davet edildiği firmalar yer alır.
    }
}
