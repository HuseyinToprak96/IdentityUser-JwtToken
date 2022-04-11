using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModels
{
   public class BusinessDetai
    {
        public Business business { get; set; }
        public User user { get; set; }
        public List<Invitation> Invitations { get; set; }
        public List<User> Users { get; set; }
    }
}
