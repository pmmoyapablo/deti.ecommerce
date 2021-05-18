using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Deti.Ecommerce.Servicio.WebAPI5.Modules.Swagger;
using Deti.Ecommerce.Servicio.WebAPI5.Modules.Authentication;
using Deti.Ecommerce.Servicio.WebAPI5.Modules.Automapper;
using Deti.Ecommerce.Servicio.WebAPI5.Modules.Feacture;
using Deti.Ecommerce.Servicio.WebAPI5.Modules.Injection;
using Deti.Ecommerce.Servicio.WebAPI5.Modules.Validator;

namespace Deti.Ecommerce.Servicio.WebAPI5
{
  public class Startup
  {
    readonly string myPolyce = "polyceApiEcommerce";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddFeature(this.Configuration);
      services.AddAutoMapper();
      services.AddInjection(this.Configuration);
      services.AddAuthentication(this.Configuration);
      services.AddSwageer();
      services.AddValidator();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors(myPolyce);
      app.UseAuthentication();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce V1"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
