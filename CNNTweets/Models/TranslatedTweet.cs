namespace CNNTweets.Models
{
    public class TextModel
    {
        public string Text { get; set; }
    }

    public class TranslatedTweet
    {
        public TextModel[] Translations { get; set; }
    }
}
