using Microsoft.Extensions.Logging;

namespace MDAC
{
    public class Scraper
    {
        private readonly ILogger<Scraper> logger;

        public Scraper(ILogger<Scraper> logger)
        {
            this.logger = logger;
        }

        public void Scrape()
        {

        }
    }
}
