using Microsoft.AspNetCore.Mvc;

namespace LibraryManage.Controllers
{
	public class BaseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
