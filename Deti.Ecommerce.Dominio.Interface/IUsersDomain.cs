using Deti.Ecommerce.Dominio.Entity;

namespace Deti.Ecommerce.Dominio.Interface
{
  public interface IUsersDomain
  {
    Users Authenticate(string username, string password);
  }
}
