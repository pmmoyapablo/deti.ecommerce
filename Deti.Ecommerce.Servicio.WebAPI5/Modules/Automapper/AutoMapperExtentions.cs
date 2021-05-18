using Deti.Ecommerce.Transversal.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Deti.Ecommerce.Servicio.WebAPI5.Modules.Automapper
{
  public static class AutoMapperExtentions
  {
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
      services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

      return services;
    }
  }
}
