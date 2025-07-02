using AccountingSystem;
using AccountingSystem.Models;
using AccountingSystem.Repositories;

class Program
{
  public static void Main(string[] args)
  {
    IEmployeeManager<Employee> manager = new EmployeeManager();
    EmployeeController employeeController = new EmployeeController(manager);
    
    try
    {
      while (true)
      {
        Bar();
        int bar = Convert.ToInt32(Console.ReadLine());

        switch (bar)
        {
          case 1:
            employeeController.AddFullEmployee();
            break;
          case 2:
            employeeController.AddPartEmployee();
            break;
          case 3:
            employeeController.GetInfoEmployee();
            break;
          case 4:
            employeeController.UpdateEmployee();
            break;
          case 5:
            employeeController.ListEmployee();
            break;
          case 6:
            employeeController.DeleteEmployee();
            break;
          case 7:
            return;
          default: break;
        }
      }
    }
    catch (Exception)
    {
      employeeController.DisplayErrorMessage("Неверный формат.");
    }
  }

  /// <summary>
  /// Меню.
  /// </summary>
  static void Bar()
  {
    Console.WriteLine(@" Меню:
            1. Добавить полного сотрудника
            2. Добавить частичного сотрудника
            3. Получить информацию о сотруднике
            4. Обновить данные сотрудника
            5. Все сотрудники
            6. Удалить данные сотрудника
            7. Выход из программы");
  }
}