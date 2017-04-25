using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class UserFeed
    {

        public int FeedId { get; set; }
        public string UserName{ get;set;}
        public string Comment { get; set; }
        public string Avatar { get; set; }
        public int Fyah { get; set; }
    }
}