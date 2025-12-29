using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Buses.Commands;

public class CreateBusCommand : IRequest<BaseResult<object>>
{
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public int Capacity { get; set; }
    public decimal Km { get; set; }
    public Guid CompanyId { get; set; }
    public Guid? DefaultDriverId { get; set; } // YENİ
}
