namespace AccountingSystem.Models
{
  public class PartTimeEmployee : Employee
  {
    public override string Name { get; set; } = "";
    public override decimal BaseSalary { get; set; }
    public decimal HoursWorked { get; set; }

    public override decimal CalculateSalary()
    {
      return BaseSalary * HoursWorked;
    }
    public PartTimeEmployee()
    {
      EmployeeType = EmployeeTypeEnum.PartTime;
    }
  }
}
