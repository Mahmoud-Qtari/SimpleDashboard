using AutoMapper;
using Sun.DAL.Models;
using Sun.PL.Areas.Dashboard.ViewModels;

namespace Sun.PL.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<AboutFormVm, About>().ReverseMap();
            CreateMap<About,AboutShowVm>();
            CreateMap<About, AboutDetailsVm>();

            CreateMap<ServiceFormVm, Service>().ReverseMap();
            CreateMap<Service, ServiceShowVm>();
            CreateMap<Service, ServiceDetailsVm>();

            CreateMap<ProfessionalFormVm, Professional>().ReverseMap();
            CreateMap<Professional, ProfessionalShowVm>();
            CreateMap<Professional, ProfessionalDetailsVm>();

            CreateMap<ProductFormVm, Product>().ReverseMap();
            CreateMap<Product, ProductShowVm>();
            CreateMap<Product, ProductDetailsVm>();

            CreateMap<PackageFormVm, Package>().ReverseMap();
            CreateMap<Package, PackageShowVm>();
            CreateMap<Package, PackageDetailsVm>();

            CreateMap<PackageItemFormVm, PackageItem>().ReverseMap();
            CreateMap<PackageItem, PackageItemShowVm>();
            CreateMap<PackageItem, PackageItemDetailsVm>();

        }
    }
}
