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
    public class SubjectController : BaseController
    {
        public SubjectController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchSubject objVM)
        {
            List<SearchSubject> objs = new List<SearchSubject>();

            IQueryable<Subject> query = repositoryManager.SubjectRepository.GetAllIQueryable();

            if (objVM.SubjectId != null)
            {
                query = query.Where(s => s.SubjectId == objVM.SubjectId);
            }

            if (objVM.Name != null)
            {
                query = query.Where(s => s.Name.Contains(objVM.Name));
            }

            if (objVM.Type != null)
            {
                query = query.Where(s => s.Type.StartsWith(objVM.Type));
            }

            if (objVM.Status != null)
            {
                query = query.Where(s => s.Status == objVM.Status);
            }


            var res = await query.ToListAsync();
            objs = mapper.Map<List<SearchSubject>>(res);

            if (objs.Count <= 0)
            {
                TempData["error"] = "لا يوجد نتائج لبحثك";
            }

            ViewData["Data"] = objs;

            return View();
        }

       

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubjectCreateVM obj)
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
                    var mapObj = new Subject
                    {
                        Name = obj.Name,
                        Type = obj.Type,
                        Status = obj.Status,
                    };
                    var res = await repositoryManager.SubjectRepository.Add(mapObj);
                    
                    
                    if (res != null)
                    {
                        for (int i = 0; i < obj.numberOfLecture; i++)
                        {
                            var lectureForSubject = new LectureForSubject
                            {
                                SubjectId = res.SubjectId,
                                LectureId = i + 1
                            };
                            await repositoryManager.LectureForSubjectRepository.Add(lectureForSubject);

                        }
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

        // GET: SubjectController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var item = await repositoryManager.SubjectRepository.GetObjById(id);
                if (item != null)
                {
                    
                    return View(mapper.Map<SubjectVM>(item));
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

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubjectVM obj)
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
                    if (id == obj.SubjectId)
                    {
                        var mapObj = mapper.Map<Subject>(obj);
                        var res = repositoryManager.SubjectRepository.Edit(mapObj);


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


        public async Task<ActionResult> EditLect(int id , int lectNumber)
        {
            try
            {
                var item = await repositoryManager.SubjectRepository.GetObjById(id);
                if (item != null)
                {
                    var LectForSubject = new SubjectCreateVM
                    {
                        SubjectId = item.SubjectId,
                        Name = item.Name,
                        Type = item.Type,
                        numberOfLecture = lectNumber
                    };
                    return View(LectForSubject);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditLect(int id, SubjectCreateVM obj)
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
                    if (id == obj.SubjectId)
                    {
                        List<LectureForSubject> list;

                        list = (List<LectureForSubject>)await repositoryManager.LectureForSubjectRepository.GetAllLectureForOneSubject(obj.SubjectId);

                        var remove = await repositoryManager.LectureForSubjectRepository.RemoveRange(list);
                        if (remove > 0)
                        {
                            for (int i = 0; i < obj.numberOfLecture; i++)
                            {
                                var lectureForSubject = new LectureForSubject
                                {
                                    SubjectId = id,
                                    LectureId = i + 1
                                };
                                await repositoryManager.LectureForSubjectRepository.Add(lectureForSubject);

                            }
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
                var item = await repositoryManager.SubjectRepository.GetObjById(id);
                if (item != null)
                {
                    item.Status = status;
                    var res = repositoryManager.SubjectRepository.Edit(item);
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






/*
 
<a asp-action="Edit" asp-all-route-data='@new Dictionary<string, string>{{"id",@i.SubjectId.ToString()},{"NumberOfLecture",numberOfLecture.ToString()}}' class="btn alert-info">تعديل <i class="fa fa-fw fa-edit"></i></a>

 
 <div class="form-group">
                        <label asp-for="numberOfLecture" class="col-sm-2 control-label bring_right left_text">عدد المحاضرات</label>
                        <div class="col-sm-10">
                           <select class="form-control" asp-for="numberOfLecture">
                                 @for (var i = 1; i <= num; i++)
                                 {
                                     <option value="@i">@i</option>
                                 }
                            </select>
                            <span class="text-danger" asp-validation-for="numberOfLecture"></span>
                        </div>
                    </div>


var res = await repository.GetAll();
    
    
       var num =  res.Count();




List<LectureForSubject> list;

list = (List<LectureForSubject>)await repositoryManager.LectureForSubjectRepository.GetAllLectureForOneSubject(obj.SubjectId);

var remove =await repositoryManager.LectureForSubjectRepository.RemoveRange(list);
if(remove > 0)
{
for (int i = 0; i < obj.numberOfLecture; i++)
{
var lectureForSubject = new LectureForSubject
{
    SubjectId = res.SubjectId,
    LectureId = i + 1
};
await repositoryManager.LectureForSubjectRepository.Add(lectureForSubject);

}
}



 
 
 
 */