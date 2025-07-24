using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace Dashboard.Controllers
{
    [Authorize]
    public class TeachingController : BaseController
    {
        public TeachingController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var items = await repositoryManager.TeachingRepository.GetAllInCurrentYear();
            if (items.Count > 0)
            {
                return View(mapper.Map<List<TeachingVM>>(items.ToList()));
            }
            TempData["error"] = "قم بإضافة عناصر جديدة";
            return View();
        }

        // GET: TeachingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeachingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeachingVM obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                    return View(obj);
                }
                else
                {
                    var mapObj = mapper.Map<Teaching>(obj);
                    var res = await repositoryManager.TeachingRepository.Add(mapObj);
                    if (res != null)
                    {
                        TempData["msg"] = "تمت  الأضافة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                        return View(obj);
                    }
                }

            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }

       
        public async Task<ActionResult> Delete(int TeacherID, int GroupID, int SubjectID , int MajorID , int YearID , int TermID)
        {
            try
            {
                var item = await repositoryManager.TeachingRepository.GetObjById(new object[] { TeacherID, GroupID, SubjectID, MajorID , YearID , TermID });
                if (item != null)
                {
                    var res = await repositoryManager.TeachingRepository.Remove(item);
                    if (res)
                    {
                        TempData["msg"] = "تمت العملية بنجاح ";
                    }
                    else
                    {
                        TempData["error"] = "هناك مشكلة يرجى اعادة المحاولة ";
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }
    }
}
