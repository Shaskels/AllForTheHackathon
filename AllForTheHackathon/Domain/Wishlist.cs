using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Domain
{
    public class Wishlist
    {
        public int Id { get; private set; }
        public List<int> Employees { get; private set; }

        public Wishlist(int id, List<int> employees)
        {
            Id = id;
            Employees = employees;
        }
    }
}
