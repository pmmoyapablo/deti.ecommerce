using System.Data;

namespace Deti.Ecommerce.Transversal.Common
{
  public interface IConetionFactory
  {
    IDbConnection GetConnection { get; }
  }
}
