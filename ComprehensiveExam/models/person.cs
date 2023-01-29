namespace EmployeeManagement.Models{
    public class Person
    {
        public int Id{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public Person(int id, string firstName, string lastName)
        {
            this.Id=id;
            this.FirstName=firstName;
            this.LastName=lastName;
        }

    }
}