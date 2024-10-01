using System.ComponentModel.DataAnnotations.Schema;

namespace AllForTheHackathon.Domain.Employees
{
    [Table("TeamLead")]
    public class TeamLead : Employee
    {
        public TeamLead(int idInList, string name) : base(idInList,name)
        {
        }
    }
}
