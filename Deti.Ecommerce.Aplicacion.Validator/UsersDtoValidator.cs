using System;
using FluentValidation;
using Deti.Ecommerce.Aplicacion.DTO;

namespace Deti.Ecommerce.Aplicacion.Validator
{
  public class UsersDtoValidator : AbstractValidator<UsersDTO>
  {
    public UsersDtoValidator()
    {
      RuleFor(u => u.UserName).NotNull().NotEmpty();
      RuleFor(u => u.Password).NotNull().NotEmpty();
    }
  }
}
