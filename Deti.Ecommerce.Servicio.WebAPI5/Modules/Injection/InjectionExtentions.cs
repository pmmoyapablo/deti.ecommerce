using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Deti.Ecommerce.Aplicacion.Interface;
using Deti.Ecommerce.Aplicacion.Main;
using Deti.Ecommerce.Dominio.Core;
using Deti.Ecommerce.Dominio.Interface;
using Deti.Ecommerce.Infraestructura.Data;
using Deti.Ecommerce.Infraestructura.Interface;
using Deti.Ecommerce.Infraestructura.Repository;
using Deti.Ecommerce.Transversal.Common;
using Deti.Ecommerce.Transversal.Logging;

namespace Deti.Ecommerce.Servicio.WebAPI5.Modules.Injection
{
  public static class InjectionExtentions
  {
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<IConfiguration>(configuration);
      services.AddSingleton<IConetionFactory, ConectionFactory>();
      services.AddScoped<ICustomerApplication, CustomerApplication>();
      services.AddScoped<ICustomerDomain, CustomerDomain>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IUsersApplication, UsersApplication>();
      services.AddScoped<IUsersDomain, UsersDomain>();
      services.AddScoped<IUsersReposiry, UsersRepository>();
      services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

      return services;
    }
  }
}
