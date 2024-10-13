using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Infrastructure
{
    public class DBSaver : ISaver
    {
        private ApplicationContext _context;
        public DBSaver(ApplicationContext context) 
        {
            _context = context;
        }
        public void SaveEmployees(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            _context.Juniors.AddRange(juniors);
            _context.TeamLeads.AddRange(teamLeads);
            _context.SaveChanges();
        }
        public void SaveWishlists(List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists)
        {
            _context.Wishlist.AddRange(juniorsWishlists);
            _context.Wishlist.AddRange(teamLeadsWishlists);

            for (int j = 0; j < juniorsWishlists.Count; j++)
            {
                for (int k = 0; k < juniorsWishlists[j].Employees.Count; k++)
                {
                    EmployeeInWishlist teamLeadInWishlist = new EmployeeInWishlist();
                    EmployeeInWishlist juniorInWishlist = new EmployeeInWishlist();
                    teamLeadInWishlist.Employee = juniorsWishlists[j].Employees[k];
                    juniorInWishlist.Employee = teamLeadsWishlists[j].Employees[k];
                    teamLeadInWishlist.Wishlist = juniorsWishlists[j];
                    juniorInWishlist.Wishlist = teamLeadsWishlists[j];
                    teamLeadInWishlist.PositionInList = k;
                    juniorInWishlist.PositionInList = k;
                    _context.Add(teamLeadInWishlist);
                    _context.Add(juniorInWishlist);
                }
            }
            _context.SaveChanges();
        }
        public void SaveHackathon(Hackathon hackathon)
        {
            _context.Hackathons.Add(hackathon);
            _context.SaveChanges();
        }
    }
}
