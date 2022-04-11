﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Configuration
{
   public class Client
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public List<string> Audiences { get; set; }//Erişebilecek API lar için
    }
}
