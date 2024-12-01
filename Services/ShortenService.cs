using Microsoft.EntityFrameworkCore;
using urlShortener.DbContextClass;

namespace urlShortener.Services
{
    public class ShortenService
    {
        public const int CharLength = 7;
        public const string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random random = new();
        public readonly ApplicationDbContext _dbContext;
        public async Task<string> GenShortUrl()
        {
            var codeChars = new Char[CharLength];
            while (true)
            {
                for(var i=0; i<CharLength; i++)
            {
                var randomIndex = random.Next(Alphabets.Length-1);
                codeChars[i] = Alphabets[randomIndex];
            }
            var shortUrl = new string(codeChars);
            if (!await _dbContext.urlShortener.AnyAsync(s => s.UrlCode == shortUrl))
            {
                return shortUrl;
            }

            }
        }

    }
}
