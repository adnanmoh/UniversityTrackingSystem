using AutoMapper;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;


namespace Dashboard.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IActionResult Index()
        {
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
}