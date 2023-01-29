using EmployeeManagement.Models;
namespace EmployeeManagement.Context
{
    public class ApplicationContext
    {
        public List<Employee> EmployeeList;
        private static ApplicationContext instance = null;
        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }
        public ApplicationContext()
        {
            this.EmployeeList = new List<Employee>();
        }
        public List<Employee> GetEmployees()
        {
            return this.EmployeeList;
        }

    }
}