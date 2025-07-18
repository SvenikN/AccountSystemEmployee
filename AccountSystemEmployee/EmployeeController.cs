﻿using System;
using System.Collections.Generic;
using AccountingSystem.Models;
using AccountingSystem.Repositories;
using AccountingSystem.EmployeeException;

namespace AccountingSystem
{
  /// <summary>
  /// Контроллер для управления сотрудниками.
  /// </summary>
  public class EmployeeController
  {
    #region Поля и свойства

    /// <summary>
    /// Менеджер для работы с данными сотрудников.
    /// </summary>
    private readonly IEmployeeManager<Employee> employeeManager;

    /// <summary>
    /// Представление для отображения информации о сотрудниках.
    /// </summary>
    private readonly EmployeeView employeeView;

    #endregion

    #region Методы

    #region Добавить сотрудника с фиксированым окладом.

    /// <summary>
    /// Добавить сотрудника с фиксированым окладом.
    /// </summary>
    public void AddFullEmployee()
    {
      try
      {
        var newEmployee = employeeView.AddFullEmployee();
        employeeManager.AddEmployee(newEmployee);
        employeeView.DisplayMessage("Сотрудник добавлен");
      }
      catch (FormatException)
      {
        employeeView.DisplayErrorMessage("Неверный формат данных.");
      }
      catch (DuplicateEmployeeIdException ex)
      {
        employeeView.DisplayErrorMessage($"Произошло исключение: {ex.ExceptionName}. Сообщение: {ex.Message}");
        employeeView.DisplayErrorMessage($"Некорректное значение: {ex.Value}");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при добавлении сотрудника.");
      }
    }

    #endregion 

    #region Добавить сотрудника с почасовым окладом.

    /// <summary>
    /// Добавить сотрудника с почасовым окладом.
    /// </summary>
    public void AddPartEmployee()
    {
      try
      {
        var newEmployee = employeeView.AddPartEmployee();
        employeeManager.AddEmployee(newEmployee);
        employeeView.DisplayMessage("Сотрудник добавлен");
      }
      catch (FormatException)
      {
        employeeView.DisplayErrorMessage("Неверный формат данных.");
      }
      catch (DuplicateEmployeeIdException ex)
      {
        employeeView.DisplayErrorMessage($"Произошло исключение: {ex.ExceptionName}. Сообщение: {ex.Message}");
        employeeView.DisplayErrorMessage($"Некорректное значение: {ex.Value}");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при добавлении сотрудника.");
      }
    }

    #endregion

    #region Получить информацию о сотрудниках по имени.

    /// <summary>
    /// Получить информацию о сотрудниках по имени.
    /// </summary>
    public void GetInfoEmployee()
    {
      try
      {
        var name = employeeView.DisplayInfoEmployee();
        List<Employee> listEmployee = employeeManager.GetEmployeeByName(name);
        employeeView.GetEmployeeList(listEmployee);
      }
      catch (ArgumentException ex)
      {
        employeeView.DisplayErrorMessage(ex.Message);
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при получении данных сотрудника.");
      }
    }

    #endregion

    #region Обновить данные сотрудника.

    /// <summary>
    /// Обновить данные сотрудника.
    /// </summary>
    public void UpdateEmployee()
    {
      try
      {
        var id = employeeView.DisplayIdEmployee();
        var em = employeeManager.GetEmployeeById(id);
        Employee newEmployee;

        if (em.EmployeeType == EmployeeTypeEnum.FullTime)
          newEmployee = employeeView.AddFullEmployee();
        else
          newEmployee = employeeView.AddPartEmployee();

        employeeManager.UpdateEmployee(newEmployee, id);
        employeeView.DisplayMessage("Данные сохранены");
      }
      catch (FormatException)
      {
        employeeView.DisplayErrorMessage("Неверный формат данных.");
      }
      catch (EmployeeIdNotFoundException ex)
      {
        employeeView.DisplayErrorMessage(ex.Message);
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при обновлении данныых сотрудника.");
      }
    }

    #endregion

    #region Получить всех сотрудников.

    /// <summary>
    /// Получить всех сотрудников.
    /// </summary>
    public void ListEmployee()
    {
      try
      {
        var em = employeeManager.GetAllEmployee();
        if (em.Count != 0)
          employeeView.GetEmployeeList(em);
        else employeeView.DisplayMessage("Список сотрудников пустой.");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при получении данных сотрудника.");
      }
    }

    #endregion

    #region Удалить данные сотрудника.

    /// <summary>
    /// Удалить данные сотрудника.
    /// </summary>
    public void DeleteEmployee()
    {
      try
      {
        var id = employeeView.DisplayIdEmployee();
        employeeManager.DeleteEmployee(id);
        employeeView.DisplayMessage("Данные удалены");
      }
      catch (FormatException)
      {
        employeeView.DisplayErrorMessage("Неверный формат данных.");
      }
      catch (DeleteEmployeeIdException ex)
      {
        employeeView.DisplayErrorMessage($"Произошло исключение: {ex.ExceptionName}. Сообщение: {ex.Message}");
        employeeView.DisplayErrorMessage($"Некорректное значение: {ex.Value}");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при удалении данных сотрудника.");
      }
    }

    #endregion

    #region Вывод сообщения об ошибке на консоль

    /// <summary>
    /// Вывод сообщения об ошибке на консоль
    /// </summary>
    /// <param name="message"></param>
    public void DisplayErrorMessage(string message)
      {
        employeeView.DisplayErrorMessage(message);
      }

    #endregion

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="employeeManager">Менеджер для работы с данными сотрудников.</param>
    public EmployeeController(IEmployeeManager<Employee> employeeManager)
    {
      this.employeeManager = employeeManager;
      employeeView = new EmployeeView();
    }

    #endregion
  }
}
