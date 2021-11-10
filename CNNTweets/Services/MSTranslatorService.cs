using CNNTweets.Helper;
using CNNTweets.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CNNTweets.Services
{
    public class MSTranslatorService
    {
        public async Task<List<Tweet>> TranslateTweets(List<Tweet> tweets)
        {
            string endpoint = "https://api.cognitive.microsofttranslator.com/";
            string route = "/translate?api-version=3.0&from=en&to=bs";
            string result;
            var body = new List<object>();


            foreach (var tweet in tweets)
            {
                body.Add(new { Text = tweet.Text });
            }

            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", Config.Subscription_Key);

                // Send the request and get response.
                HttpResponseMessage responseT = await client.SendAsync(request).ConfigureAwait(false);

                // Read response as a string.
                result = await responseT.Content.ReadAsStringAsync();

            }
            var translatedTweets = JsonConvert.DeserializeObject<List<TranslatedTweet>>(result);

            for (int i = 0; i < tweets.Count; i++)
            {
                tweets[i].Text = translatedTweets[i].Translations[0].Text;
            }

            return tweets;
        }
    }
}
