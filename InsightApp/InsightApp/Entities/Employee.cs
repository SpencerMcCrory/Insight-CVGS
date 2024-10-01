namespace InsightApp.Entities
{
    public class Employee
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }

        public int AccountId { get; set; } //FK
        public Account Account { get; set; }// to get the ability to have all the account detail in this model

    }
}
