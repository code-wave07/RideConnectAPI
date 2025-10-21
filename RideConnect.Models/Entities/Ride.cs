﻿using RideConnect.Models.Enums;

namespace RideConnect.Models.Entities;

public class Ride : BaseEntity
{
    public string Id { get; set; }
    public string Location { get; set; }
    public string RideTypeId { get; set; }
    public virtual RideType RideType { get; set; }
    public string DriverId { get; set; }
    public virtual ApplicationUser Driver { get; set; }
    public string PassengerId { get; set; }
    public virtual ApplicationUser Passenger { get; set; }
    public RideStatus RideStatus { get; set; }
}
