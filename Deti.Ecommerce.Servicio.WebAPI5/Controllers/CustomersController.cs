using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deti.Ecommerce.Aplicacion.DTO;
using Deti.Ecommerce.Aplicacion.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Deti.Ecommerce.Servicio.WebAPI5.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerApplication _customerApplication;

    public CustomersController(ICustomerApplication customerApplication)
    {
      _customerApplication = customerApplication;
    }

    #region Metodos Sincronos
    /// <summary>
    /// Crea un Nuevo Cliente
    /// </summary>
    /// <param name="customerDto">Cliente Nuevo</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] CustomerDTO customerDto)
    {
      if(customerDto == null)
      { return BadRequest();  }

       var response = _customerApplication.Insertar(customerDto);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    /// <summary>
    /// Acualiza un Cliente existente
    /// </summary>
    /// <param name="customerDto">Cliente a actualizar</param>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Put([FromBody] CustomerDTO customerDto)
    {
      if (customerDto == null)
      { return BadRequest(); }

      var response = _customerApplication.Update(customerDto);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    /// <summary>
    /// Elimina un Cliente existente
    /// </summary>
    /// <param name="customerId">Cliente a eliminar</param>
    /// <returns></returns>
    [HttpDelete("{customerId}")]
    public IActionResult Delete(string customerId)
    {
      if (string.IsNullOrEmpty(customerId))
      { return BadRequest(); }

      var response = _customerApplication.Delete(customerId);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    /// <summary>
    /// Obtiene un Cliente especifico
    /// </summary>
    /// <param name="customerId">Id de Cliente</param>
    /// <returns></returns>
    [HttpGet("{customerId}")]
    public IActionResult Get(string customerId)
    {
      if (string.IsNullOrEmpty(customerId))
      { return BadRequest(); }

      var response = _customerApplication.Get(customerId);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    /// <summary>
    /// Obtiene todos los Clientes
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {

      var response = _customerApplication.GetAll();

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }
    #endregion

    #region Metodos Asincronos
    [HttpPost("PostAsync")]
    public async Task<IActionResult> PostAsync([FromBody] CustomerDTO customerDto)
    {
      if (customerDto == null)
      { return BadRequest(); }

      var response = await _customerApplication.InsertarAsync(customerDto);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    [HttpPut("PutAsync")]
    public async Task<IActionResult> PutAsync([FromBody] CustomerDTO customerDto)
    {
      if (customerDto == null)
      { return BadRequest(); }

      var response = await _customerApplication.UpdateAsync(customerDto);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    [HttpDelete("DeleteAsync/{customerId}")]
    public async Task<IActionResult> DeleteAsync(string customerId)
    {
      if (string.IsNullOrEmpty(customerId))
      { return BadRequest(); }

      var response = await _customerApplication.DeleteAsync(customerId);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    [HttpGet("GetAsync/{customerId}")]
    public async Task<IActionResult> GetAsync(string customerId)
    {
      if (string.IsNullOrEmpty(customerId))
      { return BadRequest(); }

      var response = await _customerApplication.GetAsync(customerId);

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }

    [HttpGet("GetAsync")]
    public async Task<IActionResult> GetAsync()
    {

      var response = await _customerApplication.GetAllAsync();

      if (response.IsSuccess)
      { return Ok(response); }
      else
      { return BadRequest(response.Messange); }
    }
    #endregion
    
  }
}
