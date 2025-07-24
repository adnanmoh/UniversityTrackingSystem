using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace Dashboard.Controllers
{
    [Authorize]
    public class TermController : BaseController
    {
        public TermController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var items = await repositoryManager.TermRepository.GetAll();
            if (items.Count > 0)
            {
                return View(mapper.Map<List<TermVM>>(items.ToList()));
            }
            TempData["error"] = "قم بإضافة سنوات دراسية";
            return View();
        }

        // GET: TermController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TermController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TermVM obj)
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
                    var mapObj = mapper.Map<Term>(obj);
                    var res = await repositoryManager.TermRepository.Add(mapObj);
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

        // GET: TermController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.TermRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<TermVM>(item));
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

        // POST: TermController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TermVM obj)
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
                    if (id == obj.TermId)
                    {
                        var mapObj = mapper.Map<Term>(obj);
                        var res = repositoryManager.TermRepository.Edit(mapObj);
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
