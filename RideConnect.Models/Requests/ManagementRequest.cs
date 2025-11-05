using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideConnect.Models.Requests;

public class RideTypeRequest
{
    public string? Id { get; set; }
    public string RideType { get; set; }
}
