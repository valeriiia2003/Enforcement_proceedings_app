namespace Enforcement_proceedings_app.Additional_Data
{
	// Модель для пошуку віконавчого провадження на сторинці користувача
	public class DecisionModel
	{
		public int Court_id { get; set; }
		public int Dec_id { get; set; }
		public Dictionary<string,string> keyValuePairs { get; set; }
		public double Compensation { get; set; }
		public string ActionTaken { get; set; }
	}
}