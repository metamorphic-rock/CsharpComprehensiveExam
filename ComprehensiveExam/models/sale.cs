namespace EmployeeManagement.Models
{
    public class Sale
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public Sale(string name, float amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
    }
}