using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class FeedViewModel
    {
        public List<UserFeed> Feed { get; set; }
        public BlipUser User { get; set; }
        public string Message { get; set; }
    }
}