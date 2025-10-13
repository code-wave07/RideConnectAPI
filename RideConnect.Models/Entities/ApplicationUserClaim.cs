using Microsoft.AspNetCore.Identity;

namespace RideConnect.Models.Entities
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public string? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}