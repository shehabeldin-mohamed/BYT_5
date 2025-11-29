// In case you need some guidance: https://refactoring.guru/design-patterns/adapter
namespace DesignPattern.Adapter
{
    public class EmployeeAdapter : ITarget
    {
        private readonly BillingSystem thirdPartyBillingSystem = new();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            var employeeList = new List<Employee>();
            var rowCount = employeesArray.GetLength(0);

            for (var i = 0; i < rowCount; i++)
            {
                var idStr = employeesArray[i, 0];
                var name = employeesArray[i, 1];
                var designation = employeesArray[i, 2];
                var salaryStr = employeesArray[i, 3];
                
                var employee = new Employee(int.Parse(idStr), name, designation, decimal.Parse(salaryStr));
                employeeList.Add(employee);
            }
            thirdPartyBillingSystem.ProcessSalary(employeeList);
        }
    }
}
