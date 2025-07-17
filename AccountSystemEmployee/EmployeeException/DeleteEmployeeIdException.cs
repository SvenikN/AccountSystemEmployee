using System;

namespace AccountingSystem.EmployeeException
{
  /// <summary>
  /// Пользовательское исключение. Если удалякмый сотрудник с таким ID не найден.
  /// </summary>
  public class DeleteEmployeeIdException : ArgumentException
  {
    #region Поля и свойства

    /// <summary>
    /// Название исключения.
    /// </summary>
    public string ExceptionName { get; }

    /// <summary>
    /// Некорректное значение
    /// </summary>
    public int Value { get; }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Текст исключения.</param>
    public DeleteEmployeeIdException(string message, int val)
      : base(message)
    {
      ExceptionName = GetType().Name;
      Value = val;
    }

    #endregion
  }
}
