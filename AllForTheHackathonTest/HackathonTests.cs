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
                                            new Junior(1, "", new List<TeamLead>
                                            {
                                                new TeamLead(1, ""),
                                                new TeamLead(2, ""),
                                                new TeamLead(3, ""),
                                                new TeamLead(4, ""),
                                                new TeamLead(5, "")
                                            }),
                                            new Junior(2,"", new List<TeamLead>
                                            {
                                                new TeamLead(2, ""),
                                                new TeamLead(3, ""),
                                                new TeamLead(4, ""),
                                                new TeamLead(5, ""),
                                                new TeamLead(1, "")
                                            }),
                                            new Junior(3,"", new List<TeamLead>
                                            {
                                                new TeamLead(3, ""),
                                                new TeamLead(4, ""),
                                                new TeamLead(5, ""),
                                                new TeamLead(1, ""),
                                                new TeamLead(2, "")
                                            }),
                                            new Junior(4,"", new List<TeamLead>
                                            {
                                                new TeamLead(4, ""),
                                                new TeamLead(5, ""),
                                                new TeamLead(1, ""),
                                                new TeamLead(2, ""),
                                                new TeamLead(3, "")
                                            }),
                                            new Junior(5,"", new List<TeamLead>
                                            {
                                                new TeamLead(5, ""),
                                                new TeamLead(1, ""),
                                                new TeamLead(2, ""),
                                                new TeamLead(3, ""),
                                                new TeamLead(4, "")
                                            })

            },                       new List<TeamLead> {
                                            new TeamLead(1, "", new List<Junior>
                                            {
                                                new Junior(5, ""),
                                                new Junior(1, ""),
                                                new Junior(2, ""),
                                                new Junior(3, ""),
                                                new Junior(4, "")
                                            }),
                                            new TeamLead(2,"", new List<Junior>
                                            {
                                                new Junior(4, ""),
                                                new Junior(5, ""),
                                                new Junior(1, ""),
                                                new Junior(2, ""),
                                                new Junior(3, "")
                                            }),
                                            new TeamLead(3,"", new List<Junior>
                                            {
                                                new Junior(3, ""),
                                                new Junior(4, ""),
                                                new Junior(5, ""),
                                                new Junior(1, ""),
                                                new Junior(2, "")
                                            }),
                                            new TeamLead(4,"", new List<Junior>
                                            {
                                                new Junior(2, ""),
                                                new Junior(3, ""),
                                                new Junior(4, ""),
                                                new Junior(5, ""),
                                                new Junior(1, "")
                                            }),
                                            new TeamLead(5,"", new List<Junior>
                                            {
                                                new Junior(1, ""),
                                                new Junior(2, ""),
                                                new Junior(3, ""),
                                                new Junior(4, ""),
                                                new Junior(5, "")
                                            }),

            }, 3.0457};
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Hold_HarmonicMeanShouldMatchExpected(List<Junior> juniors, List<TeamLead> teamLeads, double expected)
        {
            //Arrange
            Hackathon hackathon = new Hackathon(juniors, teamLeads);
            ITeamBuildingStrategy buildingStrategy = new GaleShapleyStrategy();
            List<Team> teams = hackathon.Hold(buildingStrategy);
            HRDirector hRDirector = new HRDirector();

            //Act
            var res = hRDirector.CalculateTheHarmonicMean(teams);

            //Assert
            Assert.Equal(expected, Math.Round(res, 4));
        }
    }
}
