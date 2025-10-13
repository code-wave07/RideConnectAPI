using RideConnect.Models.Entities;

namespace RideConnect.Models.Entities
{
    public class Menu : BaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public int OrderId { get; set; }
        public IList<string>? Claims { get; set; }
    }
}