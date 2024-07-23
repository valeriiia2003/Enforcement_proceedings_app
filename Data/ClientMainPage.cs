using Enforcement_proceedings_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Enforcement_proceedings_app.Data
{
    public class ClientMainPage
    {
        // Пошук даних за ПІБ клієнта
        private EnforcementProceedingsDbContext _context;
        public ClientMainPage() => _context = new EnforcementProceedingsDbContext();

        public Dictionary<string, DateTime?> ReturnDecisionClient(int id_client, string name, string surname)
        {
			var results = from c in _context.Clients
						  join p in _context.Parties on c.ClientId equals p.ClientId
						  join cs in _context.ClientsCases on p.PartieId equals cs.PartpId
						  join e in _context.ExecutiveCases on cs.ExecCaseId equals e.CaseId
						  join d in _context.CourtDecisions on e.CaseId equals d.ExecutiveCaseId
						  where c.ClientName == name && c.ClientSurname == surname && c.ClientId == id_client
						  select new
						  {
							  d.AddtionalText,
							  d.DecisionDate
						  };

			var resultList = results.ToList(); // Execute the query to retrieve results

			if (resultList == null)
			{
				Dictionary<string, DateTime?> nonFoundResult = new Dictionary<string, DateTime?>();
				nonFoundResult.Add("no result", null);
				return nonFoundResult;
			}

			Dictionary<string, DateTime?> list = resultList.ToDictionary(x => x.AddtionalText, x => x.DecisionDate);
			return list;
		}
        public int DecisionNumber(string [] desc)
        {
			int decisionId = _context.CourtDecisions.Where(c => desc.Contains(c.AddtionalText))
							.Select(c => c.DecisionId).FirstOrDefault();

            return decisionId;
		}
        public string ReturnClientInfo(string name, string surname,int client_id)
        {
            var cityName = (from c in _context.Clients
                            join ct in _context.Cities on c.CityId equals ct.CityId
                            where c.ClientName == name && c.ClientSurname == surname 
							&& c.ClientId == client_id
							select ct.CityName).FirstOrDefault();

            if (cityName == null) {
                return "No avaliable values";
            }

            return cityName;
        }

		public string PartipicionType(string name, string surname, int client_id)
		{
			var participantType =
			(
					from pt in _context.ParticipantsTypes
					join p in _context.Parties on pt.ParticipantTypeId equals p.PtypeId
					join c in _context.Clients on p.ClientId equals c.ClientId
					where c.ClientName == name && c.ClientSurname == surname && 
					c.ClientId == client_id
					select pt.ParticipantType
			).FirstOrDefault();

            if(!string.IsNullOrEmpty(participantType))
				return participantType.ToString();

            return "N/A";
		}
	}
}
