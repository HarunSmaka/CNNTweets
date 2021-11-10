using System.Collections.Generic;

namespace CNNTweets.Models
{
    public class UrlModel
    {
        public string Url { get; set; }
    }

    public class Entity
    {
        public List<UrlModel> Urls { get; set; }
    }

    public class Tweet
    {
        public long Id { get; set; }
        public string Created_at { get; set; }
        public string Text { get; set; }
        public int Favorite_count { get; set; }
        public Entity Entities { get; set; }
    }
}
