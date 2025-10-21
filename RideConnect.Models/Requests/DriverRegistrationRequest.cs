using RideConnect.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Models.Requests
{
    public class DriverRegistrationRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string DlNumber { get; set; }
        public string VehicleMake { get; set; }
        public string CarModel { get; set; }
        public string ProductionYear { get; set; }
        public string CarColor { get; set; }
        public string CarPlateNumber { get; set; }
        public string MaxNumberOfBags { get; set; }
    }
}
