using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;

namespace Dashboard.Controllers
{
    [Authorize]
    public class GradeController : BaseController
    {
        public GradeController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
