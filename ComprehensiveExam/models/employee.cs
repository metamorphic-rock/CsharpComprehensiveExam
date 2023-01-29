namespace EmployeeManagement.Models
{
    public class Employee: Person
    {
        public string EmployeeNumber{get; set;}
        public float BaseSalary{get; set;}

        public Employee(int id, string firstName, string lastName,string employeeNumber, float baseSalary):base(id,firstName,lastName)
        {
            this.EmployeeNumber=employeeNumber;
            this.BaseSalary=baseSalary;
        }
        public virtual float GetSalary()
        {
            return BaseSalary;
        }
    }
}  