﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Deti.Ecommerce.Dominio.Entity
{
  public class Users
  {
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
  }
}