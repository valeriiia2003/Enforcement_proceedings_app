using Enforcement_proceedings_app.Models;

namespace Enforcement_proceedings_app.Data
{
	public class AuthorizationCheck
	{
		private EnforcementProceedingsDbContext enforcementProceedingsDbContext;
		public AuthorizationCheck()
			=> enforcementProceedingsDbContext = new EnforcementProceedingsDbContext();

		public (string AgencyName, string AgencySurname)? CheckUserAuthentication(string enforcement_code, int authority_id)
		{
			var authen_query = enforcementProceedingsDbContext.EnforcementAgencies
						.Join(enforcementProceedingsDbContext.Authorities,
							  ea => ea.AuthId,
							  a => a.AuthorityId,
							  (ea, a) => new { EA = ea, A = a })
						.Where(e => e.A.AuthorityCode == enforcement_code
															&& e.EA.AuthId == authority_id)
						.Select(e => new
						{
							e.EA.AgencyName,
							e.EA.AgencySurname
						}).FirstOrDefault();
			if (authen_query == null) 
				return null;

			return (authen_query.AgencyName, authen_query.AgencySurname);
		}
	}
}
