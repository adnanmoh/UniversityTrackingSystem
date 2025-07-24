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
    public class TeacherController : BaseController
    {
        public TeacherController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchTeacher objVM)
        {
            List<SearchTeacher> objs = new List<SearchTeacher>();

            IQueryable<Teacher> query = repositoryManager.TeacherRepository.GetAllIQueryable();

            if (objVM.TeacherId != null)
            {
                query = query.Where(s => s.TeacherId == objVM.TeacherId);
            }

            if (objVM.Name != null)
            {
                query = query.Where(s => s.Name.Contains(objVM.Name));
            }

            if (objVM.Phone != null)
            {
                query = query.Where(s => s.Phone.StartsWith(objVM.Phone));
            }

            if (objVM.Email != null)
            {
                query = query.Where(s => s.Email.Contains(objVM.Email));
            }

            var res = await query.ToListAsync();
            objs = mapper.Map<List<SearchTeacher>>(res);

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
                var item = await repositoryManager.TeacherRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<TeacherVM>(item));
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

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherVM obj)
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
                    var mapObj = mapper.Map<Teacher>(obj);
                    var res = await repositoryManager.TeacherRepository.CreateTeacher(mapObj);
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

        // GET: TeacherController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.TeacherRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<TeacherVM>(item));
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

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TeacherVM obj)
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
                    if (id == obj.TeacherId)
                    {
                        var mapObj = mapper.Map<Teacher>(obj);
                        var res = await repositoryManager.TeacherRepository.EditTeacher(mapObj);
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
