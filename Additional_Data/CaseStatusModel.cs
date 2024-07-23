namespace Enforcement_proceedings_app.Additional_Data
{
	public class CaseStatusModel
	{
		public int CaseId { get; set; }
		public string CaseNumbercode { get; set; }
		public string Status { get; set; }
		public DateTime? FillingDate { get; set; }
	}
}
