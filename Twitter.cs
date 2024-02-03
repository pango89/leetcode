using System;
using System.Collections.Generic;
namespace LeetCode
{
    public class Twitter
    {
        private Dictionary<int, List<int>> followMap; // A follows [A, B, C, D]
        private List<(int, int)> tweets;

        public Twitter()
        {
            followMap = new();
            tweets = new();
        }

        public void PostTweet(int userId, int tweetId)
        {
            tweets.Add((userId, tweetId));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            List<int> ans = new();

            if (!followMap.ContainsKey(userId))
                followMap.Add(userId, new List<int>());

            followMap[userId].Add(userId);

            for (int i = tweets.Count - 1; i >= 0; i--)
            {
                var (u, t) = tweets[i];

                if (followMap[userId].Contains(u))
                {
                    if (ans.Count > 10)
                        break;
                    ans.Add(t);
                }
            }

            followMap[userId].Remove(userId);
            return ans;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!followMap.ContainsKey(followerId))
                followMap.Add(followerId, new List<int>());

            followMap[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (followMap.ContainsKey(followerId))
                followMap[followerId].Remove(followeeId);
        }
    }

    /**
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */
}