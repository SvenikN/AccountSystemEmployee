using System;

namespace AccountingSystem.Models
{
  /// <summary>
  /// Зарплата рассчитывается по часам.
  /// </summary>
  public class PartTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Часовая ставка.
    /// </summary>
    public override decimal BaseSalary { get; set; }

    /// <summary>
    /// Отработанное вермя.
    /// </summary>
    public decimal HoursWorked { get; set; }

    #endregion

    #region Базовый класс

    public override string Name { get; set; } = "";

    #endregion

    #region Методы

    public override decimal CalculateSalary()
    {
      return BaseSalary * HoursWorked;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public PartTimeEmployee()
    {
      EmployeeType = EmployeeTypeEnum.PartTime;
    }

    #endregion
  }
}
