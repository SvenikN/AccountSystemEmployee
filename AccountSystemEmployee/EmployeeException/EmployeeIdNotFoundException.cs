using System;

namespace AccountingSystem.EmployeeException
{
  /// <summary>
  /// Пользовательское исключение. Если искомый сотрудник с таким ID не найден.
  /// </summary>
  public class EmployeeIdNotFoundException : Exception
  {
    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Текст исючения.</param>
    public EmployeeIdNotFoundException(string message) 
      : base(message)
    {}

    #endregion
  }
}
