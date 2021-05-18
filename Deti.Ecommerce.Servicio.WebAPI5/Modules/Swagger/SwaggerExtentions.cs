using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Deti.Ecommerce.Servicio.WebAPI5.Modules.Swagger
{
  public static class SwaggerExtentions
  {
    public static IServiceCollection AddSwageer(this IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Api Ecommerce de DETI",
          Version = "v1",
          Contact = new OpenApiContact() { Name = "Pablo Moya", Email = "pmmoyapablo@gmail.com" },
          Description = "Representa todas las Operaciones Ecommerce de DETI",
          TermsOfService = new Uri("http://0.0.0.0/"),
          License = new OpenApiLicense()
          {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license")
          }
        }
        );
        //Name_Assembly.xml DOC Summary
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "Authorization by API key.",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Name = "Authorization"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer" }
                }, new List<string>()
            }
        });

      });

      return services;
    }
  }
}