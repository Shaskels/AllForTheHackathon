using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Infrastructure
{
    public class DBSaver
    {
        public void SaveAllData(ApplicationContext context, Hackathon hackathon, decimal result, List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists, List<Team> teams)
        {
            for (int j = 0; j < juniors.Count; j++)
            {
                context.Juniors.Add(juniors[j]);
                context.TeamLeads.Add(teamLeads[j]);
            }
            context.SaveChanges();

            for (int j = 0; j < juniorsWishlists.Count; j++)
            {
                context.Wishlist.Add(juniorsWishlists[j]);
                context.Wishlist.Add(teamLeadsWishlists[j]);
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
                    context.Add(teamLeadInWishlist);
                }

            }

            hackathon.TeamLeads = teamLeads;
            hackathon.Juniors = juniors;
            hackathon.Result = result;
            hackathon.Teams = teams;
            context.Hackathons.Add(hackathon);
            context.SaveChanges();
        }
    }
}
