using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideConnect.Models.Enums;

namespace RideConnect.Models.Entities;

public class BaseEntity
{
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
