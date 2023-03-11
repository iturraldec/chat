using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChatWeb.Models;
using ChatWeb.Models.Request;

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
        User oUser = new User();

        oUser.Name = "catalina";
        oUser.Email = "catalina@gmail.com";
        oUser.Password = "1234";

        Utils.RequestUtil oRequestUtil = new Utils.RequestUtil();
        Dto.Reply oReply = await oRequestUtil.Execute<User>("http://localhost:5136/api/user/register", "POST", oUser);
        
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
