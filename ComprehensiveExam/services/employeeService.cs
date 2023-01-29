using EmployeeManagement.Models;
using EmployeeManagement.Context;
namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationContext Context;
        private List<Employee> employeeList;

        public EmployeeService() {
            Context = ApplicationContext.Instance;
            employeeList = Context.GetEmployees();
        }
        public List<Employee> GetAll()
        {
            return this.employeeList;
        }
        
        public List<Employee> GetAllSalesEmployees()
        {
            List<Employee> salesEmployees = new List<Employee>();
            
            foreach (Employee employee in employeeList) {
                if (employee.GetType() == typeof(SalesEmployee)) {
                    SalesEmployee temp = (SalesEmployee) employee;
                    salesEmployees.Add(temp);
                }
            }

            return salesEmployees;
        }

        public List<Employee> GetAllRegularEmployees()
        {
            List<Employee> RegularEmployees = new List<Employee>();
            
            foreach (Employee employee in employeeList) {
                if (employee.GetType() != typeof(SalesEmployee)) {
                    RegularEmployees.Add(employee);
                }
            }
            return RegularEmployees;
        }
        public Employee Save(Employee employee)
        {
            employeeList.Add(employee);
            return employee;
        }
        public void Delete(Employee employee)
        {
            employeeList.Remove(employee);
        }
        public void AddSale(SalesEmployee salesEmployee, Sale sale)
        {
            salesEmployee.AddSale(sale);
        }
    }
}