using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;
using Microsoft.AspNetCore.Authorization;


namespace Dashboard.Controllers
{
    [Authorize]
    public class YearController : BaseController
    {
        public YearController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var items = await repositoryManager.YearRepository.GetAll();
            if (items.Count > 0)
            {
                return View(mapper.Map<List<YearVM>>(items.ToList()));
            }
            TempData["error"] = "قم بإضافة سنوات دراسية";
            return View();
        }

        // GET: YearController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(YearVM obj)
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
                    var mapObj = mapper.Map<Year>(obj);
                    var res = await repositoryManager.YearRepository.Add(mapObj);
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

        // GET: YearController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.YearRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<YearVM>(item));
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

        // POST: YearController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, YearVM obj)
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
                    if (id == obj.YearId)
                    {
                        var mapObj = mapper.Map<Year>(obj);
                        var res =  repositoryManager.YearRepository.Edit(mapObj);
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

        public async Task<ActionResult> ChangeStatus(int id, bool status)
        {
            try
            {
                var item = await repositoryManager.YearRepository.GetObjById(id);
                if (item != null)
                {
                    item.Status = status;
                    var res =  repositoryManager.YearRepository.Edit(item);
                    if (res != null)
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
