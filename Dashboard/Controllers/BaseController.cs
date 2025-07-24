using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;

namespace Dashboard.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IRepositoryManager repositoryManager;
        protected readonly IMapper mapper;

        public BaseController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

    }
}
