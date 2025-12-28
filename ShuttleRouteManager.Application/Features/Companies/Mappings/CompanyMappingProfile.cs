using AutoMapper;
using ShuttleRouteManager.Application.Features.Companies.Commands;
using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Mappings;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, GetCompaniesQueryResult>();

        CreateMap<Company, GetCompanyByIdQueryResult>();

       
        CreateMap<Driver, DriverSummaryDto>();
        CreateMap<Bus, BusSummaryDto>();

        CreateMap<CreateCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();
    }
}
