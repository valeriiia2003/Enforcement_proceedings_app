using Enforcement_proceedings_app.Additional_Data;
using Enforcement_proceedings_app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Enforcement_proceedings_app.Controllers
{
    // Контролер для головної сторінки користувача 
    public class HomePage : Controller
    {
        private readonly ClientMainPage _clientMainPage;
        public HomePage() => _clientMainPage = new ClientMainPage();

		public IActionResult WebSite()
        {
            return View();
        }
        public IActionResult CustomerInfo(string surname, string name, int unique_number)
        {
            string cityOfliving = _clientMainPage.ReturnClientInfo(name, surname, unique_number);

            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name))
            {

                ModelState.AddModelError("", "Fields can not be empty.");
                return View();
            }
            Dictionary<string, DateTime?> model = _clientMainPage
                                .ReturnDecisionClient(unique_number, name, surname);

            string[] keysArray = model.Keys.ToArray();

            CombinedModel combinedModel = new CombinedModel
            {
                Name = name, Surname = surname, CityOfLiving = cityOfliving,
				NumberCourt = _clientMainPage.DecisionNumber(keysArray),
				TypeParty = _clientMainPage.PartipicionType(name,surname, unique_number),
				Id = unique_number, modelDictionary = model
            };
            return View(combinedModel);
        }
        public IActionResult Enforcement_Proceedings(int court_number, int decision_id)
        {
            ClientCaseSearch caseSearch = new ClientCaseSearch();

            var iactionmodel = new DecisionModel()
            {
                Court_id = court_number, Dec_id = decision_id,
				keyValuePairs = caseSearch.PartiesCaseSearch(court_number,decision_id),
                Compensation = caseSearch.CompensationCourt(court_number), ActionTaken = caseSearch.ActionTakenMethod(court_number)
            };

			return View(iactionmodel);
        }
	}
}
