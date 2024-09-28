namespace AllForTheHackathon.Domain.Employees
{
    public class TeamLead : Employee
    {
        public List<Junior> Wishlist { get; private set; } = new List<Junior>();
        public TeamLead(int id, string name) : base(id, name)
        {
        }

        public TeamLead(int id, string name, List<Junior> juniors) : base(id, name)
        {
            Wishlist = juniors;
        }
    }
}
