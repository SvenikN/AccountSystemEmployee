using System;
using System.Collections.Generic;

namespace AccountingSystem.Models
{
  public abstract class Employee
  {
    /// <summary>
    /// Id сотрудника.
    /// </summary>
    public int Id { get; set; } = 1;

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Базовая ставка сотрудника.
    /// </summary>
    public abstract decimal BaseSalary { get; set; }

    /// <summary>
    /// Тип сотрудника.
    /// </summary>
    public EmployeeTypeEnum EmployeeType { get; set; }

    /// <summary>
    /// Вычисление зарплаты сотрудника.
    /// </summary>
    /// <returns>Зарплата сотрудника.</returns>
    public abstract decimal CalculateSalary();
  }
}
