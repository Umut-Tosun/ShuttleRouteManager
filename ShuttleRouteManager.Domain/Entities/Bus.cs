using ShuttleRouteManager.Domain.Absractions;
using ShuttleRouteManager.Domain.Entities;

public class Bus : Entity
{
   
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public int Capacity { get; set; }
    public decimal Km { get; set; }

    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = default!;

    
    public Guid? DefaultDriverId { get; set; }
    public virtual Driver? DefaultDriver { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}