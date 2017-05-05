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
        public List<int> LikesByUserIds { get; set; }

        public int LikesCount {
            get
            {
                return LikesByUserIds.Count;
            }
            set
            {
                //do nothing on set
            }
        }

        public UserFeed()
        {
            LikesByUserIds = new List<int>();
        }

        public int AddLike(int userId)
        {
            if (LikesByUserIds.Contains(userId))
                return LikesCount;

            LikesByUserIds.Add(userId);

            return LikesCount;
        }

        
    }
}