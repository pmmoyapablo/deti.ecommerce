using System.Data;
using Deti.Ecommerce.Infraestructura.Interface;
using Deti.Ecommerce.Dominio.Entity;
using Deti.Ecommerce.Transversal.Common;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Deti.Ecommerce.Infraestructura.Repository
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly IConetionFactory _conectionFactory;
    public CustomerRepository(IConetionFactory conetionFactory)
    {
      _conectionFactory = conetionFactory;
    }

    public bool Delete(string customerId)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersDelete";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customerId);

        var result = conection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
      }
    }

    public async Task<bool> DeleteAsync(string customerId)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersDelete";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customerId);

        var result = await conection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
      }
    }

    public Customer Get(string customerId)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customerId);

        var customer = conection.QuerySingle<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);

        return customer;
      }
    }

    public IEnumerable<Customer> GetAll()
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersList";

        var customers = conection.Query<Customer>(query, commandType: CommandType.StoredProcedure);

        return customers;
      }
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersList";

        var customers = await conection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);

        return customers;
      }
    }

    public async Task<Customer> GetAsync(string customerId)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersGetByID";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customerId);

        var customer = await conection.QuerySingleAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);

        return customer;
      }
    }

    public bool Insertar(Customer customer)
    {
      using(var conection = _conectionFactory.GetConnection )
      {
        var query = "CustomersInsert";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customer.CustomerID);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("CompanyName", customer.CompanyName);
        parameters.Add("ContactName", customer.ContactName);
        parameters.Add("ContactTitle", customer.ContactTitle);
        parameters.Add("Country", customer.Country);
        parameters.Add("Fax", customer.Fax);
        parameters.Add("Phone", customer.Phone);
        parameters.Add("PostalCode", customer.PostalCode);
        parameters.Add("Region", customer.Region);

        var result = conection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
      }
    }

    public async Task<bool> InsertarAsync(Customer customer)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersInsert";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customer.CustomerID);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("CompanyName", customer.CompanyName);
        parameters.Add("ContactName", customer.ContactName);
        parameters.Add("ContactTitle", customer.ContactTitle);
        parameters.Add("Country", customer.Country);
        parameters.Add("Fax", customer.Fax);
        parameters.Add("Phone", customer.Phone);
        parameters.Add("PostalCode", customer.PostalCode);
        parameters.Add("Region", customer.Region);

        var result = await conection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
      }
    }

    public bool Update(Customer customer)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customer.CustomerID);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("CompanyName", customer.CompanyName);
        parameters.Add("ContactName", customer.ContactName);
        parameters.Add("ContactTitle", customer.ContactTitle);
        parameters.Add("Country", customer.Country);
        parameters.Add("Fax", customer.Fax);
        parameters.Add("Phone", customer.Phone);
        parameters.Add("PostalCode", customer.PostalCode);
        parameters.Add("Region", customer.Region);

        var result = conection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
      }
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
      using (var conection = _conectionFactory.GetConnection)
      {
        var query = "CustomersUpdate";
        var parameters = new DynamicParameters();
        parameters.Add("CustomerID", customer.CustomerID);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("CompanyName", customer.CompanyName);
        parameters.Add("ContactName", customer.ContactName);
        parameters.Add("ContactTitle", customer.ContactTitle);
        parameters.Add("Country", customer.Country);
        parameters.Add("Fax", customer.Fax);
        parameters.Add("Phone", customer.Phone);
        parameters.Add("PostalCode", customer.PostalCode);
        parameters.Add("Region", customer.Region);

        var result = await conection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
      }
    }
  }
}
