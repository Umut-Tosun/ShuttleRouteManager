using AutoMapper;
using ShuttleRouteManager.Application.Features.Companies.Commands;
using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Mappings;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, GetCompaniesQueryResult>().ReverseMap();
        CreateMap<Company, GetCompanyByIdQueryResult>().ReverseMap();
        CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
    }
}
