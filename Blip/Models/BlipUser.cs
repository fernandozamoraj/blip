using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class BlipUser
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get
            {
                return "@" + UserName;
            }
        }
        public string AvatarImagePath
        {
            get
            {
                return "/Content/Images/" + Avatar;
            }
        }
    }
}