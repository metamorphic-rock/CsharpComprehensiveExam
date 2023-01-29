using EmployeeManagement.Services;
using EmployeeManagement.Models;
using EmployeeManagement.Commands;
namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEmployeeService employeeService = new EmployeeService();
            List<Employee> employeeList = employeeService.GetAll();

            bool quit = false;

            while(quit)
            {
                
                Console.WriteLine("1- List all Employee");
                Console.WriteLine("2- Save Employee Record");
                Console.WriteLine("3- Delete an Employee Record");
                Console.WriteLine("4- Add a sale to a selected sales employee");
                Console.WriteLine("5- Quit");
                Console.Write("Pick an Option: ");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    if (employeeList.Count > 0)
                    {
                        List<Employee> normalEmployeeList = employeeService.GetAllRegularEmployees();
                        Console.WriteLine("List of Employees..");
                        foreach (Employee employee in normalEmployeeList)
                        {
                            DisplayEmployee(employee);
                            Console.WriteLine($"Base Salary: {employee.GetSalary()}");
                        }

                        List<Employee> salesEmployeeList = employeeService.GetAllSalesEmployees();
                        if (salesEmployeeList.Count > 0)
                        {
                            Console.WriteLine("Sales employee list: ");
                            foreach (var salesEmployee in salesEmployeeList)
                            {
                                DisplayEmployee(salesEmployee);
                                SalesEmployee temp = (SalesEmployee)salesEmployee;
                                Console.WriteLine($"Base Salary: {temp.GetSalary()}");
                                Console.WriteLine($"Commission: {temp.Commission}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Employee List is currently empty");
                    }
                }
                else if (option == 2)
                {
                    {
                        Console.WriteLine("========== EMPLOYEE MENU ==========");
                        Console.WriteLine("What type of Employee?");
                        Console.WriteLine("1 - Normal Employee");
                        Console.WriteLine("2 - Sales Employee");
                        Console.WriteLine("===================================");
                        Console.Write("Enter number: ");

                        int choice = Convert.ToInt32(Console.ReadLine());
                        int id;

                        if (employeeList.Count > 0)
                        {
                            id = employeeList.Last().Id + 1;
                        }
                        else
                        {
                            id = 1;
                        }

                        if (choice == 1 || choice == 2)
                        {
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter Employee Number: ");
                            string empNum = Console.ReadLine();

                            Console.Write("Enter Base Salary: ");
                            float baseSalary = float.Parse(Console.ReadLine());

                            if (choice == 1)
                            {
                                Employee emp = new Employee(id, firstName, lastName, empNum, baseSalary);
                                employeeService.Save(emp);
                            }
                            else if (choice == 2)
                            {
                                Console.Write("Enter Commission: ");
                                float commission = float.Parse(Console.ReadLine());

                                SalesEmployee salesEmployee = new SalesEmployee(id, firstName, lastName, empNum, baseSalary, commission);
                                employeeService.Save(salesEmployee);
                            }

                            Console.WriteLine("You have added an employee");
                        }
                        else
                        {
                            Console.WriteLine("ERROR. Invalid option");
                        }
                    };
                }
                else if (option == 3)
                {
                    Console.Write("Enter the employee ID to be deleted: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Employee employee = FindEmployee(employeeList, id);

                    if (employee != null)
                    {
                        employeeService.Delete(employee);
                        Console.WriteLine($"EMPLOYEE ID {id} DELETED");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Enter ID of Sales Employee: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Employee employee = FindEmployee(employeeList, id);

                    if (employee != null)
                    {
                        if (employeeService.GetAllSalesEmployees().Contains(employee))
                        {
                            SalesEmployee temp = (SalesEmployee)employee;
                            Console.WriteLine("ADDING SALE..");
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Amount: ");
                            float amount = float.Parse(Console.ReadLine());

                            Sale sale = new Sale(name, amount);
                            employeeService.AddSale(temp, sale);
                            Console.WriteLine($"You have added a sale");
                        }
                        else
                        {
                            Console.WriteLine($"The ID you have enter is not a sales employee.");
                        }
                    }
                }
                else if (option == 5)
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("ERROR. Invalid option");
                }
            };
        }

        public static void DisplayEmployee(Employee employee)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"Full Name: {employee.FirstName} {employee.LastName}");
            Console.WriteLine($"Employee Number: {employee.EmployeeNumber}");
        }

        public static Employee FindEmployee(List<Employee> employeeList, int id)
        {
            Employee employee = employeeList.SingleOrDefault(x => x.Id == id);

            if (employee == null)
            {
                Console.WriteLine($"ERROR. Employee ID {id} not found.");
            }

            return employee;

        }
    }
}

