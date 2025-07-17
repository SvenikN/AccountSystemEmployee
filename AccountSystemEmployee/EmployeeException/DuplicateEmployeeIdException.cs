using System;

namespace AccountingSystem.EmployeeException
{
  /// <summary>
  /// Пользовательское исключение. Если добавляемый сотрудник с таким ID уже существует.
  /// </summary>
  public class DuplicateEmployeeIdException : ArgumentException
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

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Текст исключения</param>
    public DuplicateEmployeeIdException(string message, int val)
     : base(message) 
    {
      ExceptionName = GetType().Name;
      Value = val;
    }

    #endregion
  }
}
