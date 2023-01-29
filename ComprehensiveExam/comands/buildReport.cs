using EmployeeManagement;
using EmployeeManagement.Services;
using EmployeeManagement.Models;
using System.Text.Json;
namespace EmployeeManagement.Commands
{
    public class BuildReport
    {
        EmployeeService employeeService;
        List<Employee> regularEmployees;
        List<SalesEmployee> salesEmployees;
        List<Object> formattedEmployee;
        List<Object> formattedSalesEmployee;
        List<Employee> EmployeeList;
        float totalSales;
        float totalCommission;
        public BuildReport()
        {
            employeeService = new EmployeeService();
        }

        public string Execute()
        {
            this.regularEmployees=employeeService.GetAllRegularEmployees();
            this.salesEmployees=employeeService.GetAllSalesEmployees().Cast<SalesEmployee>().ToList();
            var seralizerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            Dictionary<string, object> jsonObject = new Dictionary<string, object>();
            jsonObject.Add("employees", formattedEmployee);
            jsonObject.Add("salesEmployees", formattedSalesEmployee);

            SalesEmployee se = salesEmployees.FirstOrDefault(x => x.Sales.Count > 0);

            if (se != null) {
                jsonObject.Add("totalSales", totalSales);
                jsonObject.Add("totalCommission", totalCommission);
            }
            
            string jsonFormat = JsonSerializer.Serialize(jsonObject, seralizerOptions);
            return jsonFormat;
        }
        private void FormatData() {
            formattedEmployee = new List<object>();
            formattedSalesEmployee = new List<object>();
            totalSales = 0.0f;
            totalCommission = 0.0f;

            formattedEmployee = regularEmployees.Select(e => new { e.Id, e.EmployeeNumber, e.FirstName, e.LastName, e.BaseSalary }).ToList<Object>();
            formattedSalesEmployee = salesEmployees.Select(se => new { se.Id, se.EmployeeNumber, se.FirstName, se.LastName, se.BaseSalary, se.Commission }).ToList<Object>();
            
            totalSales = salesEmployees.Sum(se=> se.GetSalary());
            totalCommission = salesEmployees.Sum(se => (se.GetSalary() * se.Commission));
        }
    }
}