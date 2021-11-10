using CNNTweets.Models;
using CNNTweets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CNNTweets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TwitterAPIService _twitterAPIService;
        private readonly MSTranslatorService _mSTranslatorService;

        public HomeController(ILogger<HomeController> logger, TwitterAPIService twitterAPIService, MSTranslatorService mSTranslatorService)
        {
            _logger = logger;
            _twitterAPIService = twitterAPIService;
            _mSTranslatorService = mSTranslatorService;
        }

        public async Task<IActionResult> Index()
        {
            var tweets = new List<Tweet>();
            var errorString = "";

            try
            {
                tweets = await _twitterAPIService.GetTweetsAsync();
            }
            catch (Exception e)
            {
                errorString = $"ERROR: {e.Message}";
            }

            ViewBag.errorString = errorString;

            return View(tweets);
        }

        [HttpPost]
        public ActionResult SaveTweets(List<Tweet> tweets)
        {
            var errorString = "";
            try
            {
                var jsonFile = "Tweets.json";
                if (!System.IO.File.Exists(jsonFile))
                {
                    using var fileStream = new FileStream(jsonFile, FileMode.Create);
                }

                var serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented
                };

                using (var streamWriter = new StreamWriter(jsonFile))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                        serializer.Serialize(writer, tweets);
                }
            }
            catch (Exception e)
            {

                errorString = $"ERROR: {e.Message}";
            }
            
            ViewBag.errorString = errorString;

            return View("Index", tweets);
        }

        public async Task<IActionResult> GetTweetsInBosnian()
        {
            var tweets = new List<Tweet>();
            var errorString = "";

            try
            {
                tweets = await _twitterAPIService.GetTweetsAsync();
                await _mSTranslatorService.TranslateTweets(tweets);
            }
            catch (Exception e)
            {
                errorString = $"ERROR: {e.Message}";
            }

            ViewBag.errorString = errorString;
            ViewBag.isInBosnian = true;

            return View("Index", tweets);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
