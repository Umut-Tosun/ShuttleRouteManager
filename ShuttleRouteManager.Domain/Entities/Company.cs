using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public class Company : Entity
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ResponsiblePerson { get; set; } = default!;
    public string ResponsiblePersonPhoneNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public DateTimeOffset ContractDate { get; set; } 
    public DateTimeOffset ContractEndDate { get; set; }
    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();
}
