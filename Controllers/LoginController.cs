using Microsoft.AspNetCore.Mvc;
using WEBSITE2023.Models;
using WEBSITE2023.Services;

namespace WEBSITE2023.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ProcessLogin(UserModel userModel)
		{
			SecurityService securityService = new SecurityService();

				if (securityService.IsValid(userModel))
			    {
				return View("LoginSuccess", userModel);
			    }


			else
			{
				return View("LoginFailure", userModel);
			}
		}
	}
}
