using Deti.Ecommerce.Dominio.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deti.Ecommerce.Infraestructura.Interface
{
  public interface ICustomerRepository
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
