using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace Dashboard.Controllers
{
    [Authorize]
    public class NotificationController : BaseController
    {
        public NotificationController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
