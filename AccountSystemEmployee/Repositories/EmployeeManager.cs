using AccountingSystem.EmployeeException;
using AccountingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingSystem.Repositories
{
  /// <summary>
  /// Менеджер для управления списком сотрудников.
  /// </summary>
  public class EmployeeManager : IEmployeeManager<Employee>
  {
    #region Поля и свойства

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
      employee.Id = nextId++;
      if (employees.Any(e => e.Id == employee.Id))
      {
        throw new DuplicateEmployeeIdException("Сотрудник с ID уже существует.", employee.Id);
      }
      employees.Add(employee);
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
      List<Employee> foundEmployee = employees.Where(e => e.Name.ToLower() == name.ToLower()).ToList();
      if (foundEmployee.Count == 0)
      {
        throw new ArgumentException($"Сотрудников с именем {name} не найден.");
      }
      return foundEmployee;
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
      var foundEmployee = employees.FirstOrDefault(e => e.Id == id);
      if (foundEmployee == null)
      {
        throw new EmployeeIdNotFoundException($"Сотрудник c ID = {id} не найден.");
      }
      return foundEmployee;
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
        throw new EmployeeIdNotFoundException($"Сотрудник c ID = {id} не найден.");
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
    /// <param name="employee">Сотрудник которого нужно удалить.</param>
    public void DeleteEmployee(int id)
    {
      var foundEmployee = employees.FirstOrDefault(e => e.Id == id);
      if (foundEmployee == null)
      {
        throw new DeleteEmployeeIdException("Сотрудник c ID не найден.", id);
      }

      employees.Remove(foundEmployee);
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
