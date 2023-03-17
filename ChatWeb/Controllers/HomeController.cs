using System.Diagnostics;
using ChatWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ChatWeb.Business;

namespace ChatWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {  

        UtilitiesChat.Tools.RequestUtil oRequestUtil = new UtilitiesChat.Tools.RequestUtil();
        UtilitiesChat.Models.WS.Reply oReply = await oRequestUtil.Get(Constants.LIST);

        Debug.Write(oReply);
        return View();
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
