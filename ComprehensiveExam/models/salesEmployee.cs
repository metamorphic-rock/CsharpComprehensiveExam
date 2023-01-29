namespace EmployeeManagement.Models
{
    public class SalesEmployee : Employee
    {
        public float Commission { get; set; }
        public List<Sale> Sales{ get; set; }

        public SalesEmployee(int id, string firstName, string lastName, string employeeNumber, float baseSalary, float commission)
        : base(id, firstName, lastName, employeeNumber, baseSalary)
        {
            Commission = commission;
            Sales = new List<Sale>();
        }
        public void AddSale(Sale sale) {
            this.Sales.Add(sale);
        }
        public override float GetSalary()
        {
            float salary = BaseSalary + Commission * Sales.Count;
            return salary;
            
        }
        public float GetTotalSale() {
            float totalSales = 0.0f;

            foreach (var sale in Sales) {
                totalSales += sale.Amount;
            }

            return totalSales;
        }
    }
}