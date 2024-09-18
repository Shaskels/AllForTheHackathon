using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public class Wishlist
    {
        public List<Employee> wishlist { get; set; }

        public Wishlist(List<Employee> wishlist) 
        {
            this.wishlist = wishlist;
        }
    }
}
