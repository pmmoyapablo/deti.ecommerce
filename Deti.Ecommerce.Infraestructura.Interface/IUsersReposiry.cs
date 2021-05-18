using Deti.Ecommerce.Dominio.Entity;

namespace Deti.Ecommerce.Infraestructura.Interface
{
  public interface IUsersReposiry
  {
    Users Authenticate(string username, string password);
  }
}
