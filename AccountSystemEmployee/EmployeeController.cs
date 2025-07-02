using AccountingSystem.Models;
using AccountingSystem.Repositories;

namespace AccountingSystem
{
  public class EmployeeController
  {
    private readonly IEmployeeManager<Employee> employeeManager;
    private readonly EmployeeView employeeView;

    public EmployeeController(IEmployeeManager<Employee> employeeManager)
    {
      this.employeeManager = employeeManager;
      employeeView = new EmployeeView();
    }

    #region

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
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при добавлении сотрудника.");
      }
    }

    #endregion 

    #region

    /// <summary>
    /// Добавить сотрудника с почасовой окладом.
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
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при добавлении сотрудника.");
      }
    }

    #endregion

    #region

    /// <summary>
    /// Получить информацию о сотрудниках по имени.
    /// </summary>

    public void GetInfoEmployee()
    {
      try
      {
        var name = employeeView.DisplayInfoEmployee();
        List<Employee> listEmployee = employeeManager.GetEmployeeByName(name);
        if (listEmployee != null && listEmployee.Count > 0)
          employeeView.GetEmployeeList(listEmployee);
        else employeeView.DisplayMessage("Не найдено");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при получении данных сотрудника.");
      }
    }

    #endregion

    #region

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
        if (em != null)
        {
          if (em.EmployeeType == EmployeeTypeEnum.FullTime)
            newEmployee = employeeView.AddFullEmployee();
          else
            newEmployee = employeeView.AddPartEmployee();

          employeeManager.UpdateEmployee(newEmployee, id);
          employeeView.DisplayMessage("Данные сохранены");
        }
        else employeeView.DisplayMessage("Не найдено");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при обновлении данныых сотрудника.");
      }
    }

    #endregion

    #region

    /// <summary>
    /// Получить всех сотрудников.
    /// </summary>
    public void ListEmployee()
    {
      try
      {
        var em = employeeManager.GetAllEmployee();
        if (em != null)
          employeeView.GetEmployeeList(em);
        else employeeView.DisplayMessage("Не найдено");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при получении данных сотрудника.");
      }
    }

    #endregion

    #region

    /// <summary>
    /// Удалить данные сотрудника.
    /// </summary>

    public void DeleteEmployee()
    {
      try
      {
        var id = employeeView.DisplayIdEmployee();
        var em = employeeManager.GetEmployeeById(id);
        if (em != null)
        {
          employeeManager.DeleteEmployee(em);
          employeeView.DisplayMessage("Данные удалены");
        }
        else employeeView.DisplayMessage("Не найдено");
      }
      catch (Exception)
      {
        employeeView.DisplayErrorMessage("Произошла ошибка при удалении данных сотрудника.");
      }
    }

    #endregion

    #region

    /// <summary>
    /// Вывод сообщения об ошибке на консоль
    /// </summary>
    /// <param name="message"></param>
    public void DisplayErrorMessage(string message)
      {
        employeeView.DisplayErrorMessage(message);
      }

    #endregion
  }
}
