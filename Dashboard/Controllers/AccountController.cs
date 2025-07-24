using AutoMapper;
using Dashboard.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace UAppDashboard.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly UserManager<SysUser> userManager;
        private readonly SignInManager<SysUser> signInManager;
        public AccountController(UserManager<SysUser> userManager, SignInManager<SysUser> signInManager , IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        public async Task<IActionResult> Index()
        {

            var res = await userManager.Users.ToListAsync();
            if(res.Count > 0)
            {
                return View(mapper.Map<List<UserVM>>(res));
            }

            TempData["error"] = "لا يوجد مستخدمين الرجاء اعادة المحاولة";
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
        public async Task<ActionResult> Create(UserVM obj)
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
                    var user = new SysUser()
                    {
                        UserName = obj.UserName,
                        Name = obj.Name,

                    };
                    var res = await userManager.CreateAsync(user , obj.Password);
                    if (res.Succeeded)
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM obj )
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
                    var res = await signInManager.PasswordSignInAsync(obj.UserName, obj.Password, obj.RememeberMe, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index" , "Home");
                    }
                    TempData["error"] = "كلمة المرور واسم المستخدم غير متطابقين";
                    return View(obj);
                }

            }
            catch 
            {

                TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                return View();
            }
            
        }

        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var item = await userManager.FindByIdAsync(id);
                if (item != null)
                {
                    var res = await userManager.DeleteAsync(item);
                    if (res.Succeeded)
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

        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> MyAccount()
        {

            var res = await userManager.GetUserAsync(User);
            if (res != null)
            {
                return View(mapper.Map<UserVM>(res));
            }

            TempData["error"] = "هناك مشكلة الرجاء اعادة المحاولة";
            return View();

        }

        public async Task<IActionResult> ChangePassword(string id)
        {

           
                return View();
           

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordVM obj)
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
                    
                    var res = await userManager.RemovePasswordAsync(await userManager.GetUserAsync(User));
                    if (res.Succeeded)
                    {
                        var resAdd = await userManager.AddPasswordAsync(await userManager.GetUserAsync(User), obj.Password);
                        if (resAdd.Succeeded)
                        {
                            TempData["msg"] = "تمت العملية بنجاح ";
                            return RedirectToAction(nameof(MyAccount));
                        }
                        TempData["error"] = "هناك مشكلة في معالجة طلبك الرجاء اعادة المحاولة";
                        return View(obj);
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
    }
}
