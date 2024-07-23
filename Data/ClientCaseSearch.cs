using Enforcement_proceedings_app.Models;
using System;

namespace Enforcement_proceedings_app.Data
{
	public class ClientCaseSearch
	{
		// Пошук за виконавчим провадженням зі сторони клієнта
		private EnforcementProceedingsDbContext _context;
		public ClientCaseSearch() => _context = new EnforcementProceedingsDbContext();

		public Dictionary<string, string> PartiesCaseSearch(int court_num, int decision_num)
		{
			var result = from ea in _context.ExecutiveActions
						 join c in _context.CourtDecisions on ea.DecisionId equals c.DecisionId
						 join e in _context.ExecutiveCases on c.ExecutiveCaseId equals e.CaseId
						 join cc in _context.ClientsCases on e.CaseId equals cc.ExecCaseId
						 join r in _context.Parties on cc.PartpId equals r.PartieId
						 join cl in _context.Clients on r.ClientId equals cl.ClientId
						 where ea.ActionId == court_num && ea.DecisionId == decision_num
						 select new
						 {
							 cl.ClientName,
							 cl.ClientSurname
						 };
			if (result.Count() == 0)
				return new Dictionary<string, string>();

			Dictionary<string, string> clientList = result.ToDictionary(item => item.ClientName,
								item => item.ClientSurname);
			return clientList;
		}

		public double CompensationCourt(int court_num)
		{
			var compensation = _context.ExecutiveActions.Where(e => e.ActionId == court_num)
				.Select(e => e.Compensation).FirstOrDefault();
			if(compensation is not null) {
				double returnCompensation = (double)compensation;
				return returnCompensation;
			}
			return 0.0;
		}

		public string ActionTakenMethod(int court_num)
		{
			var compensation = _context.ExecutiveActions.Where(e => e.ActionId == court_num)
				.Select(e => e.ActionTaken).FirstOrDefault();
			if (compensation is not null)
			{
				string returnCompensation = compensation.ToString();
				return returnCompensation;
			}
			return string.Format("");
		}
	}
}
