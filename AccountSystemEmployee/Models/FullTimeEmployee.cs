using System;

namespace AccountingSystem.Models
{
  /// <summary>
  /// Зарплата фиксированная.
  /// </summary>
  public class FullTimeEmployee : Employee
  {

    #region Поля и свойства

    /// <summary>
    /// Базовая ставка сотрудника.
    /// </summary>
    public override decimal BaseSalary { get; set; }

    #endregion

    #region Базовый класс

    public override string Name { get; set; } = "";

    #endregion

    #region Методы

    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public FullTimeEmployee()
    {
      EmployeeType = EmployeeTypeEnum.FullTime;
    }

    #endregion
  }
}
