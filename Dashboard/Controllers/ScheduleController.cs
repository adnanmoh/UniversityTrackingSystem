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
    public class ScheduleController : BaseController
    {
        public ScheduleController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult StudentSchedule()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> StudentSchedule(SearchStudentSchedule objVM)
        {
            List<SearchStudentSchedule> objs = new List<SearchStudentSchedule>();

            IQueryable<StudentSchedule> query = repositoryManager.StudentScheduleRepository.GetAllIQueryable();

            if (objVM.ScheduleId != null)
            {
                query = query.Where(s => s.ScheduleId == objVM.ScheduleId);
            }

            if (objVM.GroupId != null)
            {
                query = query.Where(s => s.GroupId == objVM.GroupId);
            }

            if (objVM.YearId != null)
            {
                query = query.Where(s => s.YearId == objVM.YearId);
            }


            var res = await query.ToListAsync();
            objs = mapper.Map<List<SearchStudentSchedule>>(res);

            if (objs.Count <= 0)
            {
                TempData["error"] = "لا يوجد نتائج لبحثك";
            }

            ViewData["Data"] = objs;

            return View();
        }

        public ActionResult CreateStudentSchedule()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStudentSchedule(StudentScheduleVM obj , IFormFile file)
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
                    if (file.Length > 1 * 1024 * 1024)
                    {
                        TempData["error"] = "الملف الذي تم ارفاقة كبير للغاية ، قم بختيار ملف اصغر حجماً";
                        return View(obj);
                    }

                    if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        TempData["error"] = "الملف الذي تم ارفاقة غير معتمد قم بختيار ملف من نوع PDF";
                        return View(obj);
                    }
                    byte[] temp;
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        temp = target.ToArray();
                    }
                    var mapObj = new StudentSchedule()
                    {
                        ScheduleId = obj.ScheduleId,
                        GroupId = obj.GroupId,
                        YearId = obj.YearId,
                        TermId = obj.TermId,
                        Sfile = temp
                    };
                    var res = await repositoryManager.StudentScheduleRepository.Add(mapObj);
                    if (res != null)
                    {
                        TempData["msg"] = "تمت  الأضافة بنجاح";
                        return RedirectToAction(nameof(StudentSchedule));
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



        public async Task<ActionResult> EditStudentSchedule(int id)
        {

            try
            {
                var item = await repositoryManager.StudentScheduleRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<StudentScheduleVM>(item));
                        
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

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudentSchedule(int id, StudentScheduleVM obj, IFormFile file)
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
                    if (id == obj.ScheduleId)
                    {
                        if (file.Length > 1 * 1024 * 1024)
                        {
                            TempData["error"] = "الملف الذي تم ارفاقة كبير للغاية ، قم بختيار ملف اصغر حجماً";
                            return View(obj);
                        }

                        if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            TempData["error"] = "الملف الذي تم ارفاقة غير معتمد قم بختيار ملف من نوع PDF";
                            return View(obj);
                        }
                        byte[] temp;
                        using (var target = new MemoryStream())
                        {
                            file.CopyTo(target);
                            temp = target.ToArray();
                        }
                        var mapObj = new StudentSchedule()
                        {
                            ScheduleId = obj.ScheduleId,
                            GroupId = obj.GroupId,
                            YearId = obj.YearId,
                            TermId = obj.TermId,
                            Sfile = temp
                        };
                        var res = repositoryManager.StudentScheduleRepository.Edit(mapObj);
                        if (res != null)
                        {
                            TempData["msg"] = "تم التعديل بنجاح";
                            return RedirectToAction(nameof(StudentSchedule));
                        }
                    }


                    TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                    return View(obj);

                }

            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }

    


        public async Task<ActionResult> DownloadStudentSchedule(int id )
        {
            try
            {
                var item = await repositoryManager.StudentScheduleRepository.GetObjById(id);
                if (item != null)
                {
                    if(item.Sfile == null)
                    {
                        TempData["error"] = "ليس هناك ملف لتنزيله";
                        return RedirectToAction(nameof(StudentSchedule));
                    }
                    byte[] byteArr = item.Sfile;
                    string type = "application/pdf";
                    return new FileContentResult(byteArr, type)
                    {
                        FileDownloadName = $"StudentSchedule {item.ScheduleId}.pdf",



                    };
                    return View(mapper.Map<StudentScheduleVM>(item));
                }
                else
                {
                    TempData["error"] = "هناك مشكلة يرجى اعادة المحاولة ";
                    return RedirectToAction(nameof(StudentSchedule));
                }

            }
            catch
            {

                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return RedirectToAction(nameof(StudentSchedule));
            }
        }


         public ActionResult TeacherSchedule()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TeacherSchedule(SearchTeacherSchedule objVM)
        {
            List<SearchTeacherSchedule> objs = new List<SearchTeacherSchedule>();

            IQueryable<TeacherSchedule> query = repositoryManager.TeacherScheduleRepository.GetAllIQueryable();

            if (objVM.ScheduleId != null)
            {
                query = query.Where(s => s.ScheduleId == objVM.ScheduleId);
            }

            if (objVM.TeacherId != null)
            {
                query = query.Where(s => s.TeacherId == objVM.TeacherId);
            }

            if (objVM.YearId != null)
            {
                query = query.Where(s => s.YearId == objVM.YearId);
            }


            var res = await query.ToListAsync();
            objs = mapper.Map<List<SearchTeacherSchedule>>(res);

            if (objs.Count <= 0)
            {
                TempData["error"] = "لا يوجد نتائج لبحثك";
            }

            ViewData["Data"] = objs;

            return View();
        }

        public ActionResult CreateTeacherSchedule()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeacherSchedule(TeacherScheduleVM obj , IFormFile file)
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
                    if (file.Length > 1 * 1024 * 1024)
                    {
                        TempData["error"] = "الملف الذي تم ارفاقة كبير للغاية ، قم بختيار ملف اصغر حجماً";
                        return View(obj);
                    }

                    if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        TempData["error"] = "الملف الذي تم ارفاقة غير معتمد قم بختيار ملف من نوع PDF";
                        return View(obj);
                    }
                    byte[] temp;
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        temp = target.ToArray();
                    }
                    var mapObj = new TeacherSchedule()
                    {
                        ScheduleId = obj.ScheduleId,
                        TeacherId = obj.TeacherId,
                        YearId = obj.YearId,
                        TermId = obj.TermId,
                        Sfile = temp
                    };
                    var res = await repositoryManager.TeacherScheduleRepository.Add(mapObj);
                    if (res != null)
                    {
                        TempData["msg"] = "تمت  الأضافة بنجاح";
                        return RedirectToAction(nameof(TeacherSchedule));
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



        public async Task<ActionResult> EditTeacherSchedule(int id)
        {

            try
            {
                var item = await repositoryManager.TeacherScheduleRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<TeacherScheduleVM>(item));
                        
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

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeacherSchedule(int id, TeacherScheduleVM obj, IFormFile file)
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
                    if (id == obj.ScheduleId)
                    {
                        if (file.Length > 1 * 1024 * 1024)
                        {
                            TempData["error"] = "الملف الذي تم ارفاقة كبير للغاية ، قم بختيار ملف اصغر حجماً";
                            return View(obj);
                        }

                        if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            TempData["error"] = "الملف الذي تم ارفاقة غير معتمد قم بختيار ملف من نوع PDF";
                            return View(obj);
                        }
                        byte[] temp;
                        using (var target = new MemoryStream())
                        {
                            file.CopyTo(target);
                            temp = target.ToArray();
                        }
                        var mapObj = new TeacherSchedule()
                        {
                            ScheduleId = obj.ScheduleId,
                            TeacherId = obj.TeacherId,
                            YearId = obj.YearId,
                            TermId = obj.TermId,
                            Sfile = temp
                        };
                        var res = repositoryManager.TeacherScheduleRepository.Edit(mapObj);
                        if (res != null)
                        {
                            TempData["msg"] = "تم التعديل بنجاح";
                            return RedirectToAction(nameof(TeacherSchedule));
                        }
                    }


                    TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                    return View(obj);

                }

            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }

    


        public async Task<ActionResult> DownloadTeacherSchedule(int id )
        {
            try
            {
                var item = await repositoryManager.TeacherScheduleRepository.GetObjById(id);
                if (item != null)
                {
                    if(item.Sfile == null)
                    {
                        TempData["error"] = "ليس هناك ملف لتنزيله";
                        return RedirectToAction(nameof(TeacherSchedule));
                    }
                    byte[] byteArr = item.Sfile;
                    string type = "application/pdf";
                    return new FileContentResult(byteArr, type)
                    {
                        FileDownloadName = $"TeacherSchedule {item.ScheduleId}.pdf",



                    };
                    return View(mapper.Map<TeacherScheduleVM>(item));
                }
                else
                {
                    TempData["error"] = "هناك مشكلة يرجى اعادة المحاولة ";
                    return RedirectToAction(nameof(TeacherSchedule));
                }

            }
            catch
            {

                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return RedirectToAction(nameof(TeacherSchedule));
            }
        }

    }
}


/*
            public async Task<ActionResult> StudentScheduleDetails(int id)
        {
            try
            {
                var item = await repositoryManager.StudentScheduleRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<StudentScheduleVM>(item));
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
 
 
 */