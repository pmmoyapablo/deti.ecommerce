using Microsoft.AspNetCore.Mvc;
using Deti.Ecommerce.Aplicacion.DTO;
using Deti.Ecommerce.Aplicacion.Interface;
using Deti.Ecommerce.Servicio.WebAPI5.Helpers;
using Deti.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Deti.Ecommerce.Servicio.WebAPI5.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class UsersController : Controller
  {
    private readonly IUsersApplication _userApplication;
    private readonly AppSettings _appSettings;

    public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
    {
      _appSettings = appSettings.Value;
      _userApplication = usersApplication;
    }

    /// <summary>
    /// Autentica un Usuario y le genera su Token
    /// </summary>
    /// <param name="userDTO">Usuario</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromBody] UsersDTO userDTO)
    {
      var response = _userApplication.Authenticate(userDTO.UserName, userDTO.Password);

      if(response.IsSuccess)
      {
        if(response.Data != null)
        {
          response.Data.Token = BuildToken(response);

          return Ok(response);
        }
        else
        {
          return NotFound(response);
        }
      }

      return BadRequest(response);
    }

    private string BuildToken(Response<UsersDTO> userDTO)
    {
      var tokenhandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[] {
          new Claim(ClaimTypes.Name, userDTO.Data.UserID.ToString())
        }),
        Expires = DateTime.UtcNow.AddMinutes(10),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Issuer = _appSettings.Issuer,
        Audience = _appSettings.Audience
      };

      var token = tokenhandler.CreateToken(tokenDescriptor);
      var tokenString = tokenhandler.WriteToken(token);

      return tokenString;
    }
  }
}
