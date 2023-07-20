public interface IWebScrapingService
{
    Task<string> GetWebPageContent(String url);
    Task<string> ScrapeDataFromWebPage(string url, string xpathExpression);
}