using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Property, PropertyDto>()
                .ForMember(p => p.ManagementCompanyId, o => o.MapFrom(s => s.ManagementCompany.Id))
                .ForMember(p => p.ManagementCompanyName, o => o.MapFrom(s => s.ManagementCompany.Name));
            CreateMap<CompanyOwner, CompanyOwnerDto>();
            CreateMap<CompanyOwnership, CompanyOwnershipDto>();
            CreateMap<PrivateOwner, PrivateOwnerDto>();
            CreateMap<PrivateOwnership, PrivateOwnershipDto>();
            CreateMap<ManagementCompany, ManagementCompanyDto>();
            CreateMap<PropertyFile, PropertyFileDto>();
        }
    }
}