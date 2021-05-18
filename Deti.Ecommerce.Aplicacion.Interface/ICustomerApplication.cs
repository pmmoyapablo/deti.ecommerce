using Deti.Ecommerce.Transversal.Common;
using Deti.Ecommerce.Aplicacion.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Deti.Ecommerce.Aplicacion.Interface
{
  public interface ICustomerApplication
  {
    #region Metodos Sincronos

    Response<bool> Insertar(CustomerDTO customerDto);
    Response<bool> Update(CustomerDTO customerDto);
    Response<bool> Delete(string customerId);
    Response<CustomerDTO> Get(string customerId);
    Response<IEnumerable<CustomerDTO>> GetAll();

    #endregion 

    #region Metodos Asincronos

    Task<Response<bool>> InsertarAsync(CustomerDTO customerDto);
    Task<Response<bool>> UpdateAsync(CustomerDTO customerDto);
    Task<Response<bool>> DeleteAsync(string customerId);
    Task<Response<CustomerDTO>> GetAsync(string customerId);
    Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();

    #endregion 
  }
}
