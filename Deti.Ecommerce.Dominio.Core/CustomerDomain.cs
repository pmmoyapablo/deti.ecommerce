using Deti.Ecommerce.Infraestructura.Interface;
using Deti.Ecommerce.Dominio.Entity;
using Deti.Ecommerce.Dominio.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Deti.Ecommerce.Dominio.Core
{
  public class CustomerDomain : ICustomerDomain
  {
    private readonly ICustomerRepository _customerRepository;
    public CustomerDomain(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public bool Delete(string customerId)
    {
      return _customerRepository.Delete(customerId);
    }

    public async Task<bool> DeleteAsync(string customerId)
    {
      return await _customerRepository.DeleteAsync(customerId);
    }

    public Customer Get(string customerId)
    {
      return _customerRepository.Get(customerId);
    }

    public IEnumerable<Customer> GetAll()
    {
      return _customerRepository.GetAll();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
      return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer> GetAsync(string customerId)
    {
      return await _customerRepository.GetAsync(customerId);
    }

    public bool Insertar(Customer customer)
    {
      return _customerRepository.Insertar(customer);
    }

    public async Task<bool> InsertarAsync(Customer customer)
    {
      return await _customerRepository.InsertarAsync(customer);
    }

    public bool Update(Customer customer)
    {
      return _customerRepository.Update(customer);
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
      return await _customerRepository.UpdateAsync(customer);
    }
  }
}
