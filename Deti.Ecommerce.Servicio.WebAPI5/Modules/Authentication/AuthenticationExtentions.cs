﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Deti.Ecommerce.Servicio.WebAPI5.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using System.Text;

namespace Deti.Ecommerce.Servicio.WebAPI5.Modules.Authentication
{
  public static class AuthenticationExtentions
  {
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
      var appSettingsSection = configuration.GetSection("Config");
      services.Configure<AppSettings>(appSettingsSection);

      var appSettings = appSettingsSection.Get<AppSettings>();

      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      var Issuer = appSettings.Issuer;
      var Audience = appSettings.Audience;

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
            .AddJwtBearer(x =>
            {
              x.Events = new JwtBearerEvents
              {
                OnTokenValidated = context =>
                {
                  var userId = int.Parse(context.Principal.Identity.Name);
                  return Task.CompletedTask;
                },

                OnAuthenticationFailed = context =>
                {
                  if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                  {
                    context.Response.Headers.Add("Token-Expired", "true");
                  }
                  return Task.CompletedTask;
                }
              };
              x.RequireHttpsMetadata = false;
              x.SaveToken = false;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateAudience = true,
                ValidAudience = Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
              };
            });

      return services;
    }
  }
}
