using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace Dashboard.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        public StudentController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchStudent objVM)
        {
            List<SearchStudent> objs =new List<SearchStudent>();

            IQueryable<Student> query = repositoryManager.StudentRepository.GetAllIQueryable();

            if (objVM.StudentId != null)
            {
                query = query.Where(s => s.StudentId == objVM.StudentId);
            }

            if (objVM.Name != null)
            {
                query = query.Where(s => s.Name.Contains(objVM.Name));
            }

            if (objVM.Phone != null)
            {
                query = query.Where(s => s.Phone.StartsWith(objVM.Phone));
            }

            if (objVM.GroupId != null)
            {
                query = query.Where(s => s.GroupId == objVM.GroupId.Value);
            }

            var res = await query.ToListAsync();
            objs = mapper.Map<List<SearchStudent>>(res);

            if(objs.Count <= 0)
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
                var item = await repositoryManager.StudentRepository.GetObjById(id);
                if (item != null)
                {
                    List<GradeVM> objs = new List<GradeVM>();
                    var grade = await repositoryManager.GradeRepository.GetGradesForOneStudentInCurrentYear(id);
                    objs = mapper.Map<List<GradeVM>>(grade);
                    if (objs.Count <= 0)
                    {
                        TempData["info"] = "لا يوجد درجات للطالب";
                    }
                    ViewData["Data"] = objs;
                    return View(mapper.Map<StudentVM>(item));
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

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentVM obj)
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
                    var mapObj = mapper.Map<Student>(obj);
                    var res = await repositoryManager.StudentRepository.CreateStudent(mapObj);
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

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.StudentRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<StudentVM>(item));
                }
                else
                {
                    TempData["error"] ="هناك مشكلة يرجى اعادة المحاولة ";
                    return RedirectToAction(nameof(Index));
                }


            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentVM obj)
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
                    if (id == obj.StudentId)
                    {
                        var mapObj = mapper.Map<Student>(obj);
                        var res =await repositoryManager.StudentRepository.EditStudent(mapObj);
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
