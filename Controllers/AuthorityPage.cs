using Microsoft.AspNetCore.Mvc;

namespace Enforcement_proceedings_app.Controllers
{
	public class AuthorityPage : Controller
	{
		public IActionResult GetAuthorityData()
		{
			return View();
		}
	}
}
