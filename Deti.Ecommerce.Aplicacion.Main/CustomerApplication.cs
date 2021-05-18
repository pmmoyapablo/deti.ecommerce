using AutoMapper;
using Deti.Ecommerce.Aplicacion.DTO;
using Deti.Ecommerce.Aplicacion.Interface;
using Deti.Ecommerce.Dominio.Entity;
using Deti.Ecommerce.Dominio.Interface;
using Deti.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deti.Ecommerce.Aplicacion.Main
{
  public class CustomerApplication : ICustomerApplication
  {
    private readonly ICustomerDomain _customerDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CustomerApplication> _logger;

    public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper, IAppLogger<CustomerApplication> logger)
    {
      _customerDomain = customerDomain;
      _mapper = mapper;
      _logger = logger;
    }

    public Response<bool> Delete(string customerId)
    {
      var response = new Response<bool>();
      try
      {
        response.Data = _customerDomain.Delete(customerId);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Borrado Exitoso OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public async Task<Response<bool>> DeleteAsync(string customerId)
    {
      var response = new Response<bool>();
      try
      {
        response.Data = await _customerDomain.DeleteAsync(customerId);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Borrado Exitoso OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public Response<CustomerDTO> Get(string customerId)
    {
      var response = new Response<CustomerDTO>();
      try
      {
        var customer = _customerDomain.Get(customerId);
        response.Data = _mapper.Map<CustomerDTO>(customer);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa OK";
          _logger.LogInformation(response.Messange);
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
        _logger.LogError(ex.Message);
      }

      return response;
    }

    public Response<IEnumerable<CustomerDTO>> GetAll()
    {
      var response = new Response<IEnumerable<CustomerDTO>>();
      try
      {
        var customers = _customerDomain.GetAll();
        response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
    {
      var response = new Response<IEnumerable<CustomerDTO>>();
      try
      {
        var customers = await _customerDomain.GetAllAsync();
        response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public async Task<Response<CustomerDTO>> GetAsync(string customerId)
    {
      var response = new Response<CustomerDTO>();
      try
      {
        var customer = await _customerDomain.GetAsync(customerId);
        response.Data = _mapper.Map<CustomerDTO>(customer);
        if (response.Data != null)
        {
          response.IsSuccess = true;
          response.Messange = "Consulta Exitosa OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public Response<bool> Insertar(CustomerDTO customerDto)
    {
      var response = new Response<bool>();
      try
      {
        var customer = _mapper.Map<Customer>(customerDto);
        response.Data = _customerDomain.Insertar(customer);   
        if(response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Registro Exitoso OK";
        }

      }catch(Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public async Task<Response<bool>> InsertarAsync(CustomerDTO customerDto)
    {
      var response = new Response<bool>();
      try
      {
        var customer = _mapper.Map<Customer>(customerDto);
        response.Data = await _customerDomain.InsertarAsync(customer);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Registro Exitoso OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public Response<bool> Update(CustomerDTO customerDto)
    {
      var response = new Response<bool>();
      try
      {
        var customer = _mapper.Map<Customer>(customerDto);
        response.Data = _customerDomain.Update(customer);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Actualizacion Exitosa OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }

    public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDto)
    {
      var response = new Response<bool>();
      try
      {
        var customer = _mapper.Map<Customer>(customerDto);
        response.Data = await _customerDomain.UpdateAsync(customer);
        if (response.Data)
        {
          response.IsSuccess = true;
          response.Messange = "Actualizacion Exitosa OK";
        }

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Messange = ex.Message;
      }

      return response;
    }
  }
}
