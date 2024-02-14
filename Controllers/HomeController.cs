using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApiCall.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MvcApiCall.Controllers;

public class HomeController : Controller
{
    private readonly string _apikey;
    public HomeController(IConfiguration configuration)
    {
        _apikey = configuration["NYT"];
    }
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()
    {
        List<Article> allArticles = Article.GetArticles(_apikey);
        return View(allArticles);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
