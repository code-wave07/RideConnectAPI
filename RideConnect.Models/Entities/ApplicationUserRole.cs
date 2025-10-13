using Microsoft.AspNetCore.Identity;
using RideConnect.Models.Entities;

namespace RideConnect.Models.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}