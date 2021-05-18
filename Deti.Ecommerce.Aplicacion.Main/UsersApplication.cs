using AutoMapper;
using Deti.Ecommerce.Aplicacion.DTO;
using Deti.Ecommerce.Aplicacion.Interface;
using Deti.Ecommerce.Aplicacion.Validator;
using Deti.Ecommerce.Dominio.Interface;
using Deti.Ecommerce.Transversal.Common;
using System;

namespace Deti.Ecommerce.Aplicacion.Main
{
  public class UsersApplication : IUsersApplication
  {
    private readonly IUsersDomain _userDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UsersApplication> _logger;
    private readonly UsersDtoValidator _usersDtoValidator;

    public UsersApplication(IUsersDomain userDomain, IMapper mapper, IAppLogger<UsersApplication> logger, UsersDtoValidator usersDtoValidator)
    {
      _mapper = mapper;
      _userDomain = userDomain;
      _logger = logger;
      _usersDtoValidator = usersDtoValidator;
    }

    public Response<UsersDTO> Authenticate(string username, string password)
    {
      var response = new Response<UsersDTO>();
      var validation = _usersDtoValidator.Validate(new UsersDTO { UserName = username, Password = password });
      try
      {
        if(!validation.IsValid)
        {
          response.Messange = "Errores de validacion";
          response.Erros = validation.Errors;
          return response;
        }

        var user = _userDomain.Authenticate(username, password);
        response.Data = _mapper.Map<UsersDTO>(user);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Autenticacion Exitosa OK";
          _logger.LogInformation(response.Messange);
        }

      }
      catch (InvalidOperationException ex)
      {
        response.IsSuccess = true;
        response.Messange = "Usuario no existe";
        _logger.LogWarning(response.Messange);
      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
        _logger.LogError(response.Messange);
      }

      return response;
    }
  }
}
