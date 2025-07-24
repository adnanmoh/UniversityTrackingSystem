using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace Dashboard.Controllers
{
    [Authorize]
    public class MajorController : BaseController
    {
        public MajorController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }


        int id =0;
        public async Task<IActionResult> Index()
        {
            var items = await repositoryManager.MajorRepository.GetAll();
            if (items.Count > 0)
            {
                return View(mapper.Map<List<MajorVM>>(items.ToList()));
            }
            TempData["error"] = "قم بإضافة كلية جديدة";
            return View();
        }

        // GET: MajorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MajorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MajorVM obj)
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
                    var mapObj = mapper.Map<Major>(obj);
                    var res = await repositoryManager.MajorRepository.Add(mapObj);
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

        // GET: MajorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.MajorRepository.GetObjById(id);
                if (item != null)
                {
                    return View(mapper.Map<MajorVM>(item));
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

        // POST: MajorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MajorVM obj)
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
                    if (id == obj.MajorId)
                    {
                        var mapObj = mapper.Map<Major>(obj);
                        var res = repositoryManager.MajorRepository.Edit(mapObj);
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

        
        public async Task<ActionResult> AddSubjectForMajor(int id )
        {
            

            var res = await repositoryManager.MajorRepository.GetObjById(id);
            var obj = mapper.Map<MajorVM>(res);

            if (obj == null)
            {
                TempData["error"] = "لا يوجد نتائج لبحثك";
            }

            ViewData["Data"] = obj;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSubjectForMajor(SubjectsInMajorsLevelVM obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var res = await repositoryManager.MajorRepository.GetObjById(obj.MajorId);
                    var objtemp = mapper.Map<MajorVM>(res);
                    ViewData["Data"] = objtemp;
                    TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                    return View(obj);
                }
                else
                {
                    var valid = await repositoryManager.SubjectsInMajorsLevelRepository.ObjExists(new object[] {   obj.SubjectId, obj.MajorId });


                    if (!valid )
                    {
                        var mapObj = mapper.Map<SubjectsInMajorsLevel>(obj);
                        var res = await repositoryManager.SubjectsInMajorsLevelRepository.Add(mapObj);
                        if (res != null)
                        {
                            TempData["msg"] = "تمت  الأضافة بنجاح ";
                            int id = obj.MajorId;
                            return RedirectToAction(actionName: "SubjectDetails", routeValues: new { id = id });


                        }
                        var temp1 = await repositoryManager.MajorRepository.GetObjById(obj.MajorId);
                        ViewData["Data"] = mapper.Map<MajorVM>(temp1);
                        TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                        return View(obj);
                    }
                    var temp = await repositoryManager.MajorRepository.GetObjById(obj.MajorId);
                    ViewData["Data"] = mapper.Map<MajorVM>(temp);
                    TempData["error"] = "المادة الدراسية التي تحاول اضافتها موجودة بالفعل";
                    return View(obj);
                    
                }

            }
            catch
            {
                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
        }

        public async Task<ActionResult> SubjectDetails(int id  )
        {
            try
            {
                var objs = await repositoryManager.SubjectsInMajorsLevelRepository.GetSubjectsInMajorsLevelByMajorID(id);
                if (objs != null)
                {
                    List<SubjectsInMajorsLevel> objsList = objs.ToList();
                    List<SubjectsInMajorsLevelVM> a = mapper.Map<List<SubjectsInMajorsLevelVM>>(objsList);
                    return View(a);
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


        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var objs = await repositoryManager.SubjectsInMajorsLevelRepository.GetSubjectsInMajorsLevelByMajorID(id);
                if (objs != null)
                {
                    ViewData["Data"] = await repositoryManager.MajorRepository.GetObjById(@id);
                    List <SubjectsInMajorsLevel> objsList = objs.ToList();
                    List<SubjectsInMajorsLevelVM> a = mapper.Map<List<SubjectsInMajorsLevelVM>>(objsList);
                    if(a.Count <= 0)
                    {
                        TempData["error"] = "لايوجد مواد دراسية مرتبطة بهذا التخصص ";
                    }
                    return View(a);
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

    }
}
