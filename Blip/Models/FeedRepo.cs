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
            Clear();
        }

        private void AddDefaultFeeds()
        {
            UserFeed feed = new UserFeed
            {
                UserName = "Neo123",
                Avatar = "av0.PNG",
                Comment = "Programmer: A machine that turns coffee into code.",
                FeedId = 0
            };

            FeedRepo.feeds.Add(feed);


            feed = new UserFeed
            {
                UserName = "JsonData123",
                Avatar = "av4.PNG",
                Comment = "Java is to JavaScript as Ham is to Hamburger.",
                FeedId = 1
            };

            FeedRepo.feeds.Add(feed);



            feed = new UserFeed
            {
                UserName = "ZigDaMn",
                Avatar = "av7.PNG",
                Comment = "What is the object-oriented way to become wealthy? Inheritance.",
                FeedId = 2
            };

            FeedRepo.feeds.Add(feed);


        }

        public static FeedRepo Current{get{ return _repo; } }

        public void Clear()
        {
            feeds.Clear();
            feeds = new List<UserFeed>();
            AddDefaultFeeds();
        }

        public void Add(UserFeed feed)
        {
            feed.FeedId = feeds.Count+1;
            feeds.Add(feed);
        }

        public List<UserFeed> GetAll()
        {
            return feeds;
        }

        public int VoteUp(int feedId, int userId)
        {
            return feeds.First(x => x.FeedId == feedId)
                .AddLike(userId);
        }
    }
}