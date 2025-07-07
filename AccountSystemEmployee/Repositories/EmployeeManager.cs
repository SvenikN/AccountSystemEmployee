using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Models;

namespace AccountingSystem.Repositories
{
  /// <summary>
  /// Менеджер для управления списком сотрудников.
  /// </summary>
  public class EmployeeManager : IEmployeeManager<Employee>
  {
    #region Поля

    /// <summary>
    /// Список для хранения информации о сотрудниках.
    /// </summary>
    private readonly List<Employee> employees = [];

    /// <summary>
    /// Идентификатор для присвоения следующему сотруднику.
    /// </summary>
    private int nextId = 1;

    #endregion

    #region Методы

    #region Сформировать весь список сотрудников.

    /// <summary>
    /// Сформировать весь список сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    public List<Employee> GetAllEmployee()
    {
      return employees.ToList();
    }

    #endregion

    #region Добавление нового сотрудника.

    /// <summary>
    /// Добавление нового сотрудника.
    /// </summary>
    /// <param name="employee">Данные сотрудника.</param>
    public void AddEmployee(Employee employee)
    {
      employees.Add(employee);
      employee.Id = nextId++;
    }

    #endregion

    #region Получение информации о сотруднике по имени.

    /// <summary>
    /// Получение информации о сотруднике по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns>Данные найденного сотрудника.</returns>
    public List<Employee> GetEmployeeByName(string name)
    {
      return employees.Where(e => e.Name.ToLower() == name.ToLower()).ToList();
    }

    #endregion

    #region Получение информации о сотруднике по ID.

    /// <summary>
    /// Получение информации о сотруднике по ID.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <returns>Данные найденного сотруднкиа.</returns>
    public Employee GetEmployeeById(int id)
    {
      return employees.FirstOrDefault(employees => employees.Id == id);
    }

    #endregion

    #region Обновление данных сотрудника.

    /// <summary>
    /// Обновление данных сотрудника.
    /// </summary>
    /// <param name="employee">Обновленные данные.</param>
    /// <param name="id">ID сортрудника.</param>
    public void UpdateEmployee(Employee employee, int id)
    {
      var existingEmployee = employees.FirstOrDefault(employees => employees.Id == id);
      if (existingEmployee == null)
      {

      }
      else
      {
        if (existingEmployee is FullTimeEmployee fullTimeEmployee)
        {
          fullTimeEmployee.Name = employee.Name;
          fullTimeEmployee.BaseSalary = employee.BaseSalary;
        }
        else if (existingEmployee is PartTimeEmployee partTimeEmployee)
        {
          partTimeEmployee.Name = employee.Name;
          partTimeEmployee.BaseSalary = partTimeEmployee.BaseSalary;
          partTimeEmployee.HoursWorked = partTimeEmployee.HoursWorked;
        }
      }
    }

    #endregion

    #region Удаление данных сотрудника.

    /// <summary>
    /// Удаление данных сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник которого нужно удлаить.</param>
    public void DeleteEmployee(Employee employee)
    {
      employees.Remove(employee);
    }

    #endregion

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public EmployeeManager() { }

    #endregion
  }
}
