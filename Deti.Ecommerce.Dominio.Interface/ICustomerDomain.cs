using Deti.Ecommerce.Dominio.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Deti.Ecommerce.Dominio.Interface
{
  public interface ICustomerDomain
  {
    #region Metodos Sincronos

    bool Insertar(Customer customer);
    bool Update(Customer customer);
    bool Delete(string customerId);
    Customer Get(string customerId);
    IEnumerable<Customer> GetAll();

    #endregion 

    #region Metodos Asincronos

    Task<bool> InsertarAsync(Customer customer);
    Task<bool> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(string customerId);
    Task<Customer> GetAsync(string customerId);
    Task<IEnumerable<Customer>> GetAllAsync();

    #endregion 
  }
}
