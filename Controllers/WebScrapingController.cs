using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
[Route("api/[controller]")]
[ApiController]
public class WebScrapingController : ControllerBase
{
    private readonly IWebScrapingService _webScrapingService;

    public WebScrapingController(IWebScrapingService webScrapingService)
    {
        _webScrapingService = webScrapingService;
    }
    [HttpGet]
    public async Task<ActionResult<string>> ScrapeData(string url, string xpathExpression)
    {
        string result = await _webScrapingService.ScrapeDataFromWebPage(url, xpathExpression);
        return Ok(result);
    }
}