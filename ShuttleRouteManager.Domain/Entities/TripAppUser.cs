using ShuttleRouteManager.Domain.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuttleRouteManager.Domain.Entities
{
    public sealed class TripAppUser : Entity
    {
        public DateTimeOffset Date { get; set; }    
        public TripType tripType { get; set; }
        public TimeSpan plannedTime { get; set; }

    }
    public enum TripType
    {
        Morning = 1,
        Evening = 2
    }
}
