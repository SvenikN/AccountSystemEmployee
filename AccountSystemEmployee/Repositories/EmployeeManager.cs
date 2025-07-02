using AccountingSystem.Models;

namespace AccountingSystem.Repositories
{
  public class EmployeeManager : IEmployeeManager<Employee>
  {
    private readonly List<Employee> employees = new List<Employee>();
    private int nextId = 1;

    public EmployeeManager() { }

    #region

    /// <summary>
    /// Сформировать весь список сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>

    public List<Employee> GetAllEmployee()
    {
      return employees.ToList();
    }

    #endregion

    #region

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

    #region

    /// <summary>
    /// Получение информации о сотруднике по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns>Данные сотрудника.</returns>
    
    public List<Employee> GetEmployeeByName(string name)
    {
      return employees.Where(e => e.Name.ToLower() == name.ToLower()).ToList();
    }

    #endregion

    #region

    /// <summary>
    /// Получение информации о сотруднике по ID.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <returns>Данные сотруднкиа.</returns>

    public Employee GetEmployeeById(int id)
    {
      return employees.FirstOrDefault(employees => employees.Id == id);
    }

    #endregion

    #region

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

    #region

    /// <summary>
    /// Удаление данных сотрудника
    /// </summary>
    /// <param name="employee"></param>

    public void DeleteEmployee(Employee employee)
    {
      employees.Remove(employee);
    }

    #endregion
  }
}
