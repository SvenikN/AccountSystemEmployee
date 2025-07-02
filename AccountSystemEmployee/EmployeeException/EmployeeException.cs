using System;
using System.Collections.Generic;
using System.Linq;
namespace AccountingSystem.EmployeeException
{
  public class EmployeeException : Exception
  {
    public EmployeeException(string message)
      : base(message) { }
  }
}
