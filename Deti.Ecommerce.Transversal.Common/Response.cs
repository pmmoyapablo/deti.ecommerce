using FluentValidation.Results;
using System.Collections.Generic;

namespace Deti.Ecommerce.Transversal.Common
{
  public class Response<T>
  {
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Messange { get; set; }
    public IEnumerable<ValidationFailure> Erros { get; set; }
  }
}
