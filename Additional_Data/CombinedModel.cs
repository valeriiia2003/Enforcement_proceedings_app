namespace Enforcement_proceedings_app.Additional_Data
{
    // Модель для виводу даних при пошуку клієнтів
    public class CombinedModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public string CityOfLiving { get; set; }
        public int NumberCourt { get; set; }
        public string TypeParty { get; set; }
        public Dictionary<string, DateTime?> modelDictionary { get; set; }
    }
}
