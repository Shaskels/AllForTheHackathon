using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain.Strategies;

namespace AllForTheHackathonTests
{
    public class HackathonTests
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<Junior> {
                                            new Junior(1, ""),
                                            new Junior(2, ""),
                                            new Junior(3, ""),
                                            new Junior(4, ""),
                                            new Junior(5, "")

            },                       new List<TeamLead> {
                                            new TeamLead(1, ""),
                                            new TeamLead(2, ""),
                                            new TeamLead(3, ""),
                                            new TeamLead(4, ""),
                                            new TeamLead(5, ""),

            }, new List<Wishlist>
            {
                new Wishlist(new List<Employee>{new TeamLead(1, ""),
                                                new TeamLead(2, ""),
                                                new TeamLead(3, ""),
                                                new TeamLead(4, ""),
                                                new TeamLead(5, "")}),
                new Wishlist(new List<Employee>{
                                                new TeamLead(2, ""),
                                                new TeamLead(3, ""),
                                                new TeamLead(4, ""),
                                                new TeamLead(5, ""),
                                                new TeamLead(1, "")}),
                new Wishlist(new List<Employee>{
                                                new TeamLead(3, ""),
                                                new TeamLead(4, ""),
                                                new TeamLead(5, ""),
                                                new TeamLead(1, ""),
                                                new TeamLead(2, "")}),
                new Wishlist(new List<Employee>{
                                                new TeamLead(4, ""),
                                                new TeamLead(5, ""),
                                                new TeamLead(1, ""),
                                                new TeamLead(2, ""),
                                                new TeamLead(3, "")}),
                new Wishlist(new List<Employee>{
                                                new TeamLead(5, ""),
                                                new TeamLead(1, ""),
                                                new TeamLead(2, ""),
                                                new TeamLead(3, ""),
                                                new TeamLead(4, "")}),

            }, new List<Wishlist> {
                new Wishlist(new List<Employee>{new Junior(5, ""),
                                                new Junior(1, ""),
                                                new Junior(2, ""),
                                                new Junior(3, ""),
                                                new Junior(4, "")}),
                new Wishlist(new List<Employee>{new Junior(4, ""),
                                                new Junior(5, ""),
                                                new Junior(1, ""),
                                                new Junior(2, ""),
                                                new Junior(3, "")}),
                new Wishlist(new List<Employee>{new Junior(3, ""),
                                                new Junior(4, ""),
                                                new Junior(5, ""),
                                                new Junior(1, ""),
                                                new Junior(2, "")}),
                new Wishlist(new List<Employee>{new Junior(2, ""),
                                                new Junior(3, ""),
                                                new Junior(4, ""),
                                                new Junior(5, ""),
                                                new Junior(1, "")}),
                new Wishlist(new List<Employee>{new Junior(1, ""),
                                                new Junior(2, ""),
                                                new Junior(3, ""),
                                                new Junior(4, ""),
                                                new Junior(5, "")}),
            },
                3.0457M};
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Hold_HarmonicMeanShouldMatchExpected(List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists, decimal expected)
        {
            //Arrange
            Hackathon hackathon = new Hackathon();
            ITeamBuildingStrategy buildingStrategy = new GaleShapleyStrategy();
            List<Team> teams = hackathon.Hold(buildingStrategy, juniors,teamLeads, juniorsWishlists, teamLeadsWishlists);
            HRDirector hRDirector = new HRDirector();

            //Act
            var res = hRDirector.CalculateTheHarmonicMean(teams);

            //Assert
            Assert.Equal(expected, Math.Round(res, 4));
        }
    }
}
