using CNNTweets.Helper;
using CNNTweets.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CNNTweets.Services
{
    public class TwitterAPIService
    {
        public async Task<List<Tweet>> GetTweetsAsync()
        {
            var tweets = new List<Tweet>();
            string response = "";

            using (var client = new HttpClient())
            {
                var url = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=CNN&count=10";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Config.Bearer_Token);
                response = await client.GetStringAsync(url);

                // Parse JSON response.
                tweets = JsonConvert.DeserializeObject<List<Tweet>>(response);
            }

            foreach (var t in tweets)
            {
                t.Created_at = t.Created_at.Split('+')[0];
                t.Text = t.Text.Split("https://")[0];
                if(t.Entities.Urls.Count == 0)
                {
                    var urlModel = new UrlModel()
                    {
                        Url = ""
                    };
                    t.Entities.Urls.Add(urlModel);
                }
            }

            return tweets;
        }
    }
}
