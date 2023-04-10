namespace WebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public int Department { get; set; }
    }
    public class Response
    {
        public int Statuscode { get; set; }
        public string Msg { get; set; }
    }
}
