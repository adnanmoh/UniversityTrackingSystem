using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;
using Microsoft.AspNetCore.Authorization;


namespace Dashboard.Controllers
{
    [Authorize]
    public class LectureController : BaseController
    {
        public LectureController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var items = await repositoryManager.LectureRepository.GetAll();
            if (items.Count > 0)
            {
                return View(mapper.Map<List<LectureVM>>(items.ToList()));
            }
            TempData["error"] = "قم بإضافة محاضرات دراسية";
            return View();
        }

        // GET: LectureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LectureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LectureVM obj)
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
                    var mapObj = mapper.Map<Lecture>(obj);
                    var res = await repositoryManager.LectureRepository.Add(mapObj);
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

        // GET: LectureController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.LectureRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<LectureVM>(item));
                }
                else
                {
                    TempData["error"] = "هناك مشكلة يرجى اعادة المحاولة ";
                    return RedirectToAction(nameof(Index));
                }


            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }

        // POST: LectureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LectureVM obj)
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
                    if (id == obj.LectureId)
                    {
                        var mapObj = mapper.Map<Lecture>(obj);
                        var res = repositoryManager.LectureRepository.Edit(mapObj);
                        if (res != null)
                        {
                            TempData["msg"] = "تم التعديل بنجاح";
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                            return View(obj);
                        }

                    }
                    TempData["error"] = "هناك مشكلة في معالجة البيانات";
                    return View(obj);
                }
            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View(obj);
            }
        }


    }
}
