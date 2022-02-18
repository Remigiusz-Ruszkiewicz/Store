namespace Store.Models
{
    public class UserResult
    {
        public string Token { get; set; }

        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
