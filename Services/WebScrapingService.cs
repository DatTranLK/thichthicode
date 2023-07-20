using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;
public class WebScrapingService : IWebScrapingService
{
    private readonly HttpClient _httpClient;
    public WebScrapingService()
    {
        _httpClient = new HttpClient();
    }
    public async Task<string> GetWebPageContent(String url)
    {
        var response = await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
    public async Task<string> ScrapeDataFromWebPage(string url, string xpathExpression)
    {
        try
        {
            string htmlContent = await GetWebPageContent(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var selectedtElemennts = doc.DocumentNode.SelectNodes(xpathExpression);
            if (selectedtElemennts != null)
            {
                return string.Join(Environment.NewLine, selectedtElemennts.Select(e => e.InnerText));
            }
            return "No data found.";
        }
        catch (System.Exception ex)
        {

            throw new Exception("Error: " + ex.Message);
        }
    }
}