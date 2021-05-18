using AutoMapper;
using Deti.Ecommerce.Aplicacion.DTO;
using Deti.Ecommerce.Dominio.Entity;

namespace Deti.Ecommerce.Transversal.Mapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Customer, CustomerDTO>().ReverseMap();
      CreateMap<Users, UsersDTO>().ReverseMap();

      //Cuando los atributos tienen denominacion diferentes o tipo diferentes
      //CreateMap<Customer, CustomerDTO>().ReverseMap()
      //  .ForMember(destination => destination.CustomerID, source => source.MapFrom(src => src.CustomerID))
      //  // ...
      //  .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName)).ReverseMap();
    }
  }
}
