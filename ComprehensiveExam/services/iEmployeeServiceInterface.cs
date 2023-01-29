using EmployeeManagement.Models;
namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public List<Employee> GetAllSalesEmployees();
        public List<Employee> GetAllRegularEmployees();
        public Employee Save(Employee employee);
        public void Delete(Employee employee);
        public void AddSale(SalesEmployee employee, Sale sale);
    }
}
