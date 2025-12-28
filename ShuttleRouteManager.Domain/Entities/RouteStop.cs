using ShuttleRouteManager.Domain.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuttleRouteManager.Domain.Entities
{
    public sealed class RouteStop : Entity
    {
       public int SequenceNumber { get; set; }
        public string City { get; set; } = default!;
        public string District { get; set; } = default!;
        public string Address { get; set; } = default!;
        public decimal Latitude { get; set; } = default!;
        public decimal Longitude { get; set; } = default!;
        public TimeSpan EstimatedArrivalTimeMorning { get; set; } = default!;
        public TimeSpan EstimatedArrivalTimeEvening { get; set; } = default!;

    }
}
