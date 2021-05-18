using System.Data;
using Deti.Ecommerce.Infraestructura.Interface;
using Deti.Ecommerce.Dominio.Entity;
using Deti.Ecommerce.Transversal.Common;
using Dapper;

namespace Deti.Ecommerce.Infraestructura.Repository
{
  public class UsersRepository : IUsersReposiry
  {
    private readonly IConetionFactory _conectionFactory;

    public UsersRepository(IConetionFactory conectionFactory)
    {
      _conectionFactory = conectionFactory;
    }
    public Users Authenticate(string username, string password)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "UsersGetByUserAndPassword";
        var parameters = new DynamicParameters();
        parameters.Add("UserName", username);
        parameters.Add("Password", password);

        var user = conection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);

        return user;
      }
    }
  }
}
