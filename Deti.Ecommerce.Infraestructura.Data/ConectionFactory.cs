using System.Data;
using Deti.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Deti.Ecommerce.Infraestructura.Data
{
  public class ConectionFactory : IConetionFactory
  {
    private readonly IConfiguration _configuration;
    public ConectionFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public IDbConnection GetConnection {
      get {
        var sqlConnetion = new SqlConnection();
        if (sqlConnetion == null)
        { return null; }

        sqlConnetion.ConnectionString = _configuration.GetConnectionString("NorthwindConection");
        sqlConnetion.Open();

        return sqlConnetion;
      }
    }
  }
}