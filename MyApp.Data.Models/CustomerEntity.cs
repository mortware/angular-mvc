namespace MyApp.Data.Models
{
    public class CustomerEntity : IEntity<string>
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
    }
}
