using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blip.Models
{
    public class FeedRepo
    {
        static List<UserFeed> feeds = new List<UserFeed>();

        static FeedRepo _repo = new FeedRepo();

        private FeedRepo()
        {
            AddDefaultFeeds();
        }

        private void AddDefaultFeeds()
        {
            UserFeed feed = new UserFeed
            {
                UserName = "JSmith456",
                Avatar = "av0.PNG",
                Comment = "I show up to school 10 minutes late... at the wrong school",
                FeedId = 0
            };

            FeedRepo.feeds.Add(feed);


            feed = new UserFeed
            {
                UserName = "EJackson123",
                Avatar = "av4.PNG",
                Comment = "This is dummy data",
                FeedId = 1
            };

            FeedRepo.feeds.Add(feed);



            feed = new UserFeed
            {
                UserName = "JOker12",
                Avatar = "av7.PNG",
                Comment = "More dummy Data",
                FeedId = 2
            };

            FeedRepo.feeds.Add(feed);


        }

        public static FeedRepo Current{get{ return _repo; } }

        public void Add(UserFeed feed)
        {
            feed.FeedId = feeds.Count;
            feeds.Add(feed);
        }

        public List<UserFeed> GetAll()
        {
            return feeds;
        }

        public void VoteUp(int feedId)
        {
            feeds.First(x => x.FeedId == feedId).Fyah += 1;
        }
    }
}