namespace HR_System.Domain.Models
{
    public class Events
    {
        public int Id { get; set; }
        public long EmployeeID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
