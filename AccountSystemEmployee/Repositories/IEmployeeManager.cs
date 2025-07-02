namespace AccountingSystem.Repositories
{
  public interface IEmployeeManager<TEmployee>
  {
    List<TEmployee>? GetAllEmployee();
    void AddEmployee(TEmployee employee);
    List<TEmployee>? GetEmployeeByName(string name);
    TEmployee GetEmployeeById(int id);
    void UpdateEmployee(TEmployee employee, int id);
    void DeleteEmployee(TEmployee employee);
  }
}
