using InStoreOrdering.IServices;
using InStoreOrdering.Models;
using InStoreOrdering.Services;
using Microsoft.AspNetCore.Mvc;

namespace InStoreOrdering.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;

        public LoginController(ILogger<LoginController> logger, ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserModel userModel)
        {
            
            return Ok(new { IsSuccess = true, Message = "加入成功" });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpInfo([FromBody] UserModel userModel)
        {
            _loginService.InsertUserInfo(userModel);
            return View();
        }
    }
}
