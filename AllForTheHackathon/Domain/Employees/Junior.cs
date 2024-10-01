using System.ComponentModel.DataAnnotations.Schema;

namespace AllForTheHackathon.Domain.Employees
{
    [Table("Junior")]
    public class Junior : Employee
    {
        public Junior(int idInList, string name) : base(idInList,name)
        {
        }
    }
}
