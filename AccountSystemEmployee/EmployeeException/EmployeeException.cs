using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingSystem.EmployeeException
{
  /// <summary>
  /// Исключения.
  /// </summary>
  public class EmployeeException : Exception
  {
    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение для пользователя.</param>
    public EmployeeException(string message)
      : base(message) { }

    #endregion
  }
}
