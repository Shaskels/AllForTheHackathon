using AllForTheHackathon.Domain.Employees;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllForTheHackathon.Domain
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [NotMapped]
        public List<Employee> Employees { get; private set; } = new();
        public Wishlist()
        {
        }
        public Wishlist(List<Employee> employees)
        {
            Employees = employees;
        }
    }
}
