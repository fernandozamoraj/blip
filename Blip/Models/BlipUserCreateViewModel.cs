using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class BlipUserCreateViewModel
    {
        public BlipUser User{get;set;}
        public List<string> Avatars { get; set; }
        public string SelectedAvatar { get; set; }
    }
}