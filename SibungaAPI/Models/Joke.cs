namespace SibungaAPI.Models
{
    public class Joke
    {
        public int id { get; set; }
        public string type { get; set; } = string.Empty;
        public string setup { get; set; } = string.Empty;
        public string punchline { get; set; } = string.Empty;
    }
}
