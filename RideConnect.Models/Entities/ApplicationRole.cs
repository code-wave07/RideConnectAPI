﻿using Microsoft.AspNetCore.Identity;

namespace RideConnect.Models.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}