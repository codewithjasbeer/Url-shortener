namespace urlShortener.Entity
{
    public class UrlShortener
    {
        public Guid id {  get; set; }
        public string Longurl { get; set; } = string.Empty;
        public string Shorturl { get; set; } = string.Empty;
        public string UrlCode {  get; set; } = string.Empty;
    }
}
