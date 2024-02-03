using System.Collections.Generic;

namespace LeetCode
{
    // public class Twitter
    // {
    //     private static int timestamp = 0;

    //     private class Tweet
    //     {
    //         public int TweetId { get; set; }
    //         public int Timestamp { get; set; }

    //         public Tweet(int tweetId, int timestamp)
    //         {
    //             this.TweetId = tweetId;
    //             this.Timestamp = timestamp;
    //         }
    //     }

    //     // UserId -> Set of UserIds this user follows
    //     Dictionary<int, HashSet<int>> userFollowing;

    //     // UserId -> Tweets
    //     Dictionary<int, List<Tweet>> userTweets;

    //     public Twitter()
    //     {
    //         this.userFollowing = new Dictionary<int, HashSet<int>>();
    //         this.userTweets = new Dictionary<int, List<Tweet>>();
    //     }

    //     public void PostTweet(int userId, int tweetId)
    //     {
    //         if (!this.userTweets.ContainsKey(userId))
    //             this.userTweets.Add(userId, new List<Tweet>());

    //         this.userTweets[userId].Add(new Tweet(tweetId, ++timestamp));
    //     }

    //     public IList<int> GetNewsFeed(int userId)
    //     {
    //         IList<int> feed = new List<int>();
    //         this.Follow(userId, userId);
    //         if (!this.userFollowing.ContainsKey(userId))
    //             return feed;

    //         PriorityQueue<Tweet, int> pq = new PriorityQueue<Tweet, int>();

    //         foreach (int fUserId in this.userFollowing[userId])
    //         {
    //             if (!this.userTweets.ContainsKey(fUserId))
    //                 continue;

    //             if (this.userTweets[fUserId] == null)
    //                 continue;

    //             List<Tweet> fUserTweets = this.userTweets[fUserId];

    //             foreach (Tweet fUserTweet in fUserTweets)
    //             {
    //                 pq.Enqueue(fUserTweet, fUserTweet.Timestamp);
    //                 if (pq.Count > 10)
    //                     pq.Dequeue();
    //             }
    //         }

    //         while (pq.Count > 0)
    //             feed.Insert(0, pq.Dequeue().TweetId);

    //         this.Unfollow(userId, userId);

    //         return feed;
    //     }

    //     public void Follow(int followerId, int followeeId)
    //     {
    //         if (!this.userFollowing.ContainsKey(followerId))
    //             this.userFollowing.Add(followerId, new HashSet<int>());

    //         this.userFollowing[followerId].Add(followeeId);
    //     }

    //     public void Unfollow(int followerId, int followeeId)
    //     {
    //         if (!this.userFollowing.ContainsKey(followerId))
    //             return;

    //         if (!this.userFollowing[followerId].Contains(followeeId))
    //             return;

    //         this.userFollowing[followerId].Remove(followeeId);
    //     }
    // }
}