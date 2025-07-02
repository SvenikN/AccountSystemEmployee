namespace AccountingSystem.Models
{
  public abstract class Employee
  {
    public int Id { get; set; } = 1;
    public abstract string Name { get; set; }
    public abstract decimal BaseSalary { get; set; }
    public EmployeeTypeEnum EmployeeType { get; set; }
    public abstract decimal CalculateSalary();
  }
}
