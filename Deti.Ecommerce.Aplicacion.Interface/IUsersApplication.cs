using Deti.Ecommerce.Transversal.Common;
using Deti.Ecommerce.Aplicacion.DTO;

namespace Deti.Ecommerce.Aplicacion.Interface
{
  public interface IUsersApplication
  {
    Response<UsersDTO> Authenticate(string username, string password);
  }
}
