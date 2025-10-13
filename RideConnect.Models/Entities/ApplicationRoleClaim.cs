using Microsoft.AspNetCore.Identity;
namespace RideConnect.Models.Entities
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public string? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}