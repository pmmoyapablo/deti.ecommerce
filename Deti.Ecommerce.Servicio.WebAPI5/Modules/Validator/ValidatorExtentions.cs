using Deti.Ecommerce.Aplicacion.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Deti.Ecommerce.Servicio.WebAPI5.Modules.Validator
{
  public static class ValidatorExtentions
  {
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
      services.AddTransient<UsersDtoValidator>();
      return services;
    }
  }
}
