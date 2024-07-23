using Enforcement_proceedings_app.Additional_Data;
using Enforcement_proceedings_app.Data;
using Enforcement_proceedings_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace Enforcement_proceedings_app.Controllers
{
	public class AuthorizationController : Controller
	{
		private readonly AuthorizationCheck authorization;
        public AuthorizationController() => authorization = new AuthorizationCheck();
        public IActionResult LoginSystem()
		{
			return View();
		}
		public IActionResult GetAuthorityData(string enforcement_code, int authority_id)
		{
			(string tuple_name, string tuple_surname)? checkValue = authorization	
										.CheckUserAuthentication(enforcement_code, authority_id);
			if(checkValue == null)
			{
				TempData["ErrorMessage"] = "Authentication failed. Please check your credentials and try again.";
				return RedirectToAction("ShowError");
			}

			return View(checkValue);
		}
		public IActionResult ShowError()
		{
			return View();
		}

		private EnforcementProceedingsDbContext enforcementProceedingsDbContext;
	public IActionResult CaseStatus(int case_id, string case_number)
		{
			enforcementProceedingsDbContext = new EnforcementProceedingsDbContext();

			var querystatus = enforcementProceedingsDbContext.ExecutiveCases
					.Where(e => e.CaseId == case_id && e.CaseNumber == case_number)
					.Select(e => new
					{
						case_status = e.CaseStatus,
						case_dec = e.CourtDecisions.ToString(),
						filling_date = e.FillingDate
					}).FirstOrDefault();

			if(querystatus is null)
				return View();
			
			CaseStatusModel model = new CaseStatusModel()
			{
				CaseId = case_id, CaseNumbercode = case_number,
				Status = querystatus.case_status,FillingDate = querystatus.filling_date
			};

			return View(model);
		}
	}
}
