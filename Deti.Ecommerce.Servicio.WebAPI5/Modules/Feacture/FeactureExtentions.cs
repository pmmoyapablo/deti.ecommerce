using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Deti.Ecommerce.Servicio.WebAPI5.Modules.Feacture
{
  public static class FeactureExtentions
  {
    
    public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
    {
      string myPolyce = "polyceApiEcommerce";
      services.AddCors(option => option.AddPolicy(myPolyce,
        builder => builder.WithOrigins(configuration["Config:OriginCors"])
        .AllowAnyHeader()
        .AllowAnyMethod()
        )
      );

      services.AddControllers();

      return services;
    }
  }
}
