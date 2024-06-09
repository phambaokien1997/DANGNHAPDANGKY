using Azure;
using BookStoreWeb.Models;
using DataAccess.BookStore.DTO;
using DataAccess.BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.VisualBasic;

namespace BookStoreWeb.Controllers
{
    public class UserController : Controller
    {
        private UserServices _userService;
        public UserController()
        {
            _userService = new UserServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostCreate([FromBody] UserModel userModel)
        {
            try
            {
                //Guid guid = Guid.NewGuid();
                //var id = guid.GetHashCode();
                //userModel.UserID = id;
                var requestUser = new UserCreateUpdateRequestData();
                requestUser.Email = userModel.Email;
                //requestUser.UserID = userModel.UserID;
                requestUser.Password = userModel.Password;
                

                //var message = await _authorService.AddAuthorAsync(id.ToString(), addAuthorModel.Ten, addAuthorModel.QueQuan);
                //addAuthorModel.ThongBao = message;
                //return View("AddAuthor", addAuthorModel);
                var respones = await _userService.UserInsertUpdateAsync(requestUser);
                
                var result = new { report = respones.ReturnMsg };
                return Json(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] UserLogin userLogin)
        {
            try
            {
                var loginUser = new UserAcountRequestData();
                loginUser.Email = userLogin.Email;
                loginUser.Password = userLogin.Password;
                var responesLogin = await _userService.UserAcountAsync(loginUser);
                var result = new { report = responesLogin.ReturnMsg };
                return Json(result);
                //có thể trả về 1 trang view cho người dùng
            }
            catch( Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
