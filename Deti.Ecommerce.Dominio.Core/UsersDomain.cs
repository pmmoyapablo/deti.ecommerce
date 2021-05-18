using Deti.Ecommerce.Infraestructura.Interface;
using Deti.Ecommerce.Dominio.Entity;
using Deti.Ecommerce.Dominio.Interface;

namespace Deti.Ecommerce.Dominio.Core
{
  public class UsersDomain : IUsersDomain
  {
    private readonly IUsersReposiry _userRepository;

    public UsersDomain(IUsersReposiry userRepository)
    {
      _userRepository = userRepository;
    }

    public Users Authenticate(string username, string password)
    {
      return _userRepository.Authenticate(username, password);
    }
  }
}
