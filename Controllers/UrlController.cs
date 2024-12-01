using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using urlShortener.DbContextClass;
using urlShortener.Entity;
using urlShortener.Models;
using urlShortener.Services;

namespace urlShortener.Controllers
{
    public class UrlController : Controller
    {
        [HttpPost("ShortenUrl")]
        public async Task<IActionResult> ShortenUrlAsync(ShortenRequest request)
        {
            ShortenService src = new ShortenService();
            ApplicationDbContext dbContext = new();
            if (!Uri.TryCreate(request.Url, UriKind.RelativeOrAbsolute, out _))
            {
                return (IActionResult)Results.BadRequest("The Specified Uri is invalid");
            }

            var shortUrlCode = await src.GenShortUrl();
            var urlShortener = new UrlShortener
            {
                id = Guid.NewGuid(),
                Longurl = request.Url.ToString(),
                UrlCode = shortUrlCode,
                Shorturl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/{shortUrlCode}"
            };
            dbContext.urlShortener.Add(urlShortener);
            await dbContext.SaveChangesAsync();
            return (IActionResult)Results.Ok(urlShortener.Shorturl);
        }

        [HttpGet("RedirectUrl")]
        public async Task<IActionResult> shortCodeUrl(string ShortUrlcode)
        {
            ApplicationDbContext context = new();
            var shortUrl = await context.urlShortener.FirstOrDefaultAsync(urlShortener => urlShortener.Shorturl == ShortUrlcode);
            if (shortUrl is null)
            {
                return (IActionResult)Results.NotFound();
            }
            return (IActionResult)Results.Redirect(shortUrl.Longurl);
        }
    }
}
