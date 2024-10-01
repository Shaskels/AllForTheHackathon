using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain.Strategies;
using Moq;

namespace AllForTheHackathonTests
{
    public class HRManagerTests
    {
        ITeamBuildingStrategy strategy;
        IWishlistsGenerator generator;
        public HRManagerTests() { 
            strategy = new GaleShapleyStrategy();
            generator = new RandomWishlistsGenerator();
        }
        public static IEnumerable<object[]> DataForFirstTest()
        {

            yield return new object[] { new List<Junior>{ new Junior(1, "Юдин Адам"),
                                           new Junior(2, "Яшина Яна"),
                                           new Junior(3, "Никитина Вероника"),
                                           new Junior(4, "Рябинин Александр"),
                                           new Junior(5, "Ильин Тимофей")},
                                        new List<TeamLead> { new TeamLead(1, "Филиппова Ульяна"),
                                           new TeamLead(2, "Николаев Григорий"),
                                           new TeamLead(3, "Андреева Вероника"),
                                           new TeamLead(4, "Коротков Михаил"),
                                           new TeamLead(5, "Кузнецов Александр")},
                                                    5 };
            yield return new object[] { new List<Junior> { }, new List<TeamLead> { } , 0 };
        }
        //public static IEnumerable<object[]> DataForSecondTest()
        //{
        //    yield return new object[] { new List<Junior> {
        //                                    new Junior(1, "", new List<TeamLead>
        //                                    {
        //                                        new TeamLead(1, ""),
        //                                        new TeamLead(2, ""),
        //                                        new TeamLead(3, ""),
        //                                        new TeamLead(4, ""),
        //                                        new TeamLead(5, "")
        //                                    }),
        //                                    new Junior(2,"", new List<TeamLead>
        //                                    {
        //                                        new TeamLead(2, ""),
        //                                        new TeamLead(3, ""),
        //                                        new TeamLead(4, ""),
        //                                        new TeamLead(5, ""),
        //                                        new TeamLead(1, "")
        //                                    }),
        //                                    new Junior(3,"", new List<TeamLead>
        //                                    {
        //                                        new TeamLead(3, ""),
        //                                        new TeamLead(4, ""),
        //                                        new TeamLead(5, ""),
        //                                        new TeamLead(1, ""),
        //                                        new TeamLead(2, "")
        //                                    }),
        //                                    new Junior(4,"", new List<TeamLead>
        //                                    {
        //                                        new TeamLead(4, ""),
        //                                        new TeamLead(5, ""),
        //                                        new TeamLead(1, ""),
        //                                        new TeamLead(2, ""),
        //                                        new TeamLead(3, "")
        //                                    }),
        //                                    new Junior(5,"", new List<TeamLead>
        //                                    {
        //                                        new TeamLead(5, ""),
        //                                        new TeamLead(1, ""),
        //                                        new TeamLead(2, ""),
        //                                        new TeamLead(3, ""),
        //                                        new TeamLead(4, "")
        //                                    })

        //    },                       new List<TeamLead> {
        //                                    new TeamLead(1, "", new List<Junior>
        //                                    {
        //                                        new Junior(5, ""),
        //                                        new Junior(1, ""),
        //                                        new Junior(2, ""),
        //                                        new Junior(3, ""),
        //                                        new Junior(4, "")
        //                                    }),
        //                                    new TeamLead(2,"", new List<Junior>
        //                                    {
        //                                        new Junior(4, ""),
        //                                        new Junior(5, ""),
        //                                        new Junior(1, ""),
        //                                        new Junior(2, ""),
        //                                        new Junior(3, "")
        //                                    }),
        //                                    new TeamLead(3,"", new List<Junior>
        //                                    {
        //                                        new Junior(3, ""),
        //                                        new Junior(4, ""),
        //                                        new Junior(5, ""),
        //                                        new Junior(1, ""),
        //                                        new Junior(2, "")
        //                                    }),
        //                                    new TeamLead(4,"", new List<Junior>
        //                                    {
        //                                        new Junior(2, ""),
        //                                        new Junior(3, ""),
        //                                        new Junior(4, ""),
        //                                        new Junior(5, ""),
        //                                        new Junior(1, "")
        //                                    }),
        //                                    new TeamLead(5,"", new List<Junior>
        //                                    {
        //                                        new Junior(1, ""),
        //                                        new Junior(2, ""),
        //                                        new Junior(3, ""),
        //                                        new Junior(4, ""),
        //                                        new Junior(5, "")
        //                                    }),

        //    },                      new List<Team> {
        //                                        new Team(new Junior(1, ""), 1, new TeamLead(5, ""), 5),
        //                                        new Team(new Junior(2, ""), 3, new TeamLead(4, ""), 5),
        //                                        new Team(new Junior(3, ""), 5, new TeamLead(3, ""), 5),
        //                                        new Team(new Junior(4, ""), 2, new TeamLead(2, ""), 5),
        //                                        new Team(new Junior(5, ""), 4, new TeamLead(1, ""), 5),
        //                                    }
        //    };
        //}

        //[Theory]
        //[MemberData(nameof(DataForFirstTest))]
        //public void HoldAHackathon_NumberOfTeamsShoultMatchPresetValue(List<Junior> juniors, List<TeamLead> teamLeads, int expectedNumberOfTeams)
        //{
        //    //Arrange
        //    HRManager hRManager = new HRManager(strategy, generator);
        //    Hackathon hackathon = new Hackathon(juniors, teamLeads);

        //    //Act
        //    List<Team> teams = hRManager.HoldAHackathon(hackathon);

        //    //Assert
        //    Assert.Equal(expectedNumberOfTeams, teams.Count);
        //}

        //[Fact]
        //public void HoldAHackathon_StrategyShouldBeCalledOnce()
        //{
        //    //Arrange
        //    Hackathon hackathon = new Hackathon(new List<Junior> { new Junior(1, "Acтафьев Андрей"), }
        //    , new List<TeamLead> { new TeamLead(1, "Костин Александр") });
        //    var mock = new Mock<ITeamBuildingStrategy>();
        //    mock.Setup(s => s.BuildTeams(hackathon.Juniors, hackathon.TeamLeads)).Returns(GetTestTeams());
        //    HRManager hRManager = new HRManager(mock.Object, generator);

        //    //Act
        //    hRManager.HoldAHackathon(hackathon);

        //    //Assert
        //    mock.Verify(s => s.BuildTeams(hackathon.Juniors, hackathon.TeamLeads), Times.Once);

        //}

        //private List<Team> GetTestTeams()
        //{
        //    var teams = new List<Team>() {
        //        new Team(new Junior(1, "Acтафьев Андрей"), 20, new TeamLead(1,"Костин Александр"), 20)
        //    };
        //    return teams;
        //}

        //[Theory]
        //[MemberData(nameof(DataForSecondTest))]
        //public void HoldAHackathon_TeamListShouldMathTeamWithPresetValue(List<Junior> juniors, List<TeamLead> teamLeads, List<Team> expectedTeams)
        //{
        //    //Arrange
        //    Hackathon hackathon = new Hackathon(juniors, teamLeads);

        //    //Act
        //    List<Team> teams = hackathon.Hold(strategy);

        //    //Assert
        //    Assert.Equal(expectedTeams, teams);
        //}
    }
}
