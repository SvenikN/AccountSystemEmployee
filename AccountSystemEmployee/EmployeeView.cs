﻿using System;
using System.Collections.Generic;
using AccountingSystem.Models;

namespace AccountingSystem
{
  /// <summary>
  /// Представление для отображения информации о сотрудниках.
  /// </summary>
  public class EmployeeView
  {
    #region Методы

    #region Ввод данных с консоли для сотрудника с фиксированной ставкой.

    /// <summary>
    /// Ввод данных с консоли для сотрудника с фиксированной ставкой.
    /// </summary>
    /// <returns>Имя, базовая ставка.</returns>
    public Employee AddFullEmployee()
    {
        Console.WriteLine($"Введите имя");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine($"Введите базовую зарплату");
        decimal baseSalary = Convert.ToDecimal(Console.ReadLine());

        return new FullTimeEmployee { Name = name, BaseSalary = baseSalary };
    }

    #endregion

    #region Ввод данных с консоли для сотрудника с почасовой ставкой.

    /// <summary>
    /// Ввод данных с консоли для сотрудника с почасовой ставкой.
    /// </summary>
    /// <returns>Имя, базовая ставка, отработанное время.</returns>
    public Employee AddPartEmployee()
    {
      Console.WriteLine($"Введите имя");
      string name = Console.ReadLine() ?? "";

      Console.WriteLine($"Введите часовую ставку");
      decimal baseSalary = Convert.ToDecimal(Console.ReadLine());

      Console.WriteLine($"Введите отработанное время");
      decimal hoursWorked = Convert.ToDecimal(Console.ReadLine());

      return new PartTimeEmployee { Name = name, BaseSalary = baseSalary, HoursWorked = hoursWorked };
    }

    #endregion

    #region Вывод на консоль списка сотрудников.

    /// <summary>
    /// Вывод на консоль списка сотрудников.
    /// </summary>
    /// <param name="listEmployee">Список сотрудников.</param>
    public void GetEmployeeList(List<Employee> listEmployee)
    {
      Console.WriteLine("Список сотрудников");
      foreach (Employee e in listEmployee)
      {
        Console.WriteLine($"ID: {e.Id}, Имя: {e.Name}, з/п: {e.CalculateSalary()}, Тип: {e.EmployeeType}");
        Console.WriteLine();
      }
    }

    #endregion

    #region Ввод имени с консоли.

    /// <summary>
    /// Ввод имени с консоли.
    /// </summary>
    /// <returns>Имя.</returns>
    public string DisplayInfoEmployee()
    {
      Console.WriteLine($"Введите имя");
      var name = Console.ReadLine();
      return name;
    }

    #endregion

    #region Ввод ID  с консоли.

    /// <summary>
    /// Ввод ID  с консоли.
    /// </summary>
    /// <returns>ID</returns>
    public int DisplayIdEmployee()
    {
      Console.WriteLine($"Введите ID сотрудника");
      var id = Convert.ToInt32(Console.ReadLine());
      return id;
    }

    #endregion

    #region Вывод на консоль информационное сообщение.

    /// <summary>
    /// Вывод на консоль информационное сообщение.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public void DisplayMessage(string message)
    {
      Console.WriteLine(message + "\n");
    }

    #endregion

    #region Вывод на консоль сообщения об ошибке.

    /// <summary>
    /// Вывод на консоль сообщения об ошибке.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public void DisplayErrorMessage(string message)
    {
      Console.WriteLine(message);
    }
  }

  #endregion

  #endregion
}
