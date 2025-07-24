using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace Dashboard.Controllers
{
    [Authorize]
    public class GroupController : BaseController
    {
        public GroupController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchGroup objVM)
        {
            List<SearchGroup> objs = new List<SearchGroup>();

            IQueryable<Group> query = repositoryManager.GroupRepository.GetAllIQueryable();

            if (objVM.GroupId != null)
            {
                query = query.Where(s => s.GroupId == objVM.GroupId);
            }

            if (objVM.Name != null)
            {
                query = query.Where(s => s.Name.Contains(objVM.Name));
            }

            if (objVM.YearId != null)
            {
                query = query.Where(s => s.YearId == objVM.YearId);
            }

            if (objVM.LevelId != null)
            {
                query = query.Where(s => s.LevelId == objVM.LevelId);
            }
            if (objVM.MajorId != null)
            {
                query = query.Where(s => s.MajorId == objVM.MajorId);
            }
            if (objVM.ParentGroupId != null)
            {
                query = query.Where(s => s.ParentGroupId == objVM.ParentGroupId);
            }

            var res = await query.ToListAsync();
            objs = mapper.Map<List<SearchGroup>>(res);

            if (objs.Count <= 0)
            {
                TempData["error"] = "لا يوجد نتائج لبحثك";
            }

            ViewData["Data"] = objs;
            

            return View();
        }

        // GET: MovieController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var item = await repositoryManager.GroupRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<GroupVM>(item));
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

        // GET: GroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GroupVM obj)
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
                    var mapObj = mapper.Map<Group>(obj);
                    var res = await repositoryManager.GroupRepository.Add(mapObj);
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

        // GET: GroupController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.GroupRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<GroupVM>(item));
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

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GroupVM obj)
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
                    if (id == obj.GroupId)
                    {
                        var mapObj = mapper.Map<Group>(obj);
                        var res =  repositoryManager.GroupRepository.Edit(mapObj);
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
