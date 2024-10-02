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
        public HRManagerTests()
        {
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
            yield return new object[] { new List<Junior> { }, new List<TeamLead> { }, 0 };
        }
        public static IEnumerable<object[]> DataForSecondTest()
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
                new List<Team> {new Team(new Junior(1, ""), 1, new TeamLead(5, ""), 5),
                                new Team(new Junior(2, ""), 3, new TeamLead(4, ""), 5),
                                new Team(new Junior(3, ""), 5, new TeamLead(3, ""), 5),
                                new Team(new Junior(4, ""), 2, new TeamLead(2, ""), 5),
                                new Team(new Junior(5, ""), 4, new TeamLead(1, ""), 5), }
            };
        }

        [Theory]
        [MemberData(nameof(DataForFirstTest))]
        public void HoldAHackathon_NumberOfTeamsShoultMatchPresetValue(List<Junior> juniors, List<TeamLead> teamLeads,int expectedNumberOfTeams)
        {
            //Arrange
            List<Wishlist> juniorsWishlists = generator.MakeWishlistsForJuniors(juniors, teamLeads);
            List<Wishlist> teamLeadsWishlists = generator.MakeWishlistsForTeamLeads(juniors, teamLeads);
            HRManager hRManager = new HRManager(strategy);
            Hackathon hackathon = new Hackathon();

            //Act
            List<Team> teams = hRManager.HoldAHackathon(hackathon, juniors, teamLeads, 
                juniorsWishlists, teamLeadsWishlists);

            //Assert
            Assert.Equal(expectedNumberOfTeams, teams.Count);
        }

        [Fact]
        public void HoldAHackathon_StrategyShouldBeCalledOnce()
        {
            //Arrange
            List<Junior> juniors = new List<Junior> { new Junior(1, "Acтафьев Андрей") };
            List<TeamLead> teamLeads = new List<TeamLead> { new TeamLead(1, "Костин Александр") };
            List<Wishlist> juniorsWishlists = new List<Wishlist>
            {
                new Wishlist(new List<Employee>{new TeamLead(1, "Костин Александр")})
            };
            List<Wishlist> teamLeadsWishlists = new List<Wishlist>
            {
                new Wishlist(new List<Employee>{new Junior(1, "Acтафьев Андрей")})
            };
            Hackathon hackathon = new Hackathon();
            var mock = new Mock<ITeamBuildingStrategy>();
            mock.Setup(s => s.BuildTeams(juniors, teamLeads, juniorsWishlists, teamLeadsWishlists)).Returns(GetTestTeams());
            HRManager hRManager = new HRManager(mock.Object);

            //Act
            hRManager.HoldAHackathon(hackathon, juniors, teamLeads, juniorsWishlists, teamLeadsWishlists);

            //Assert
            mock.Verify(s => s.BuildTeams(juniors, teamLeads, juniorsWishlists, teamLeadsWishlists), Times.Once);

        }

        private List<Team> GetTestTeams()
        {
            var teams = new List<Team>() {
                new Team(new Junior(1, "Acтафьев Андрей"), 20, new TeamLead(1,"Костин Александр"), 20)
            };
            return teams;
        }

        [Theory]
        [MemberData(nameof(DataForSecondTest))]
        public void HoldAHackathon_TeamListShouldMathTeamWithPresetValue(List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists,List<Team> expectedTeams)
        {
            //Arrange
            Hackathon hackathon = new Hackathon();

            //Act
            List<Team> teams = hackathon.Hold(strategy, juniors, teamLeads, juniorsWishlists, teamLeadsWishlists);

            //Assert
            Assert.Equal(expectedTeams, teams);
        }
    }
}
