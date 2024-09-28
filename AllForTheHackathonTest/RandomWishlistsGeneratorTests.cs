using AllForTheHackathon;
using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathonTest
{
    public class RandomWishlistsGeneratorTests
    {
        private IWishlistsGenerator wishlistsGenerator;
        private static List<Junior> juniorList = new List<Junior> { new Junior(1, "���� ����"),
                                                     new Junior(2, "����� ���"),
                                                     new Junior(3, "�������� ��������"),
                                                     new Junior(4, "������� ���������"),
                                                     new Junior(5, "����� �������")};
        private static List<TeamLead> teamLeadList = new List<TeamLead> { new TeamLead(1, "��������� ������"),
                                                             new TeamLead(2, "�������� ��������"),
                                                             new TeamLead(3, "�������� ��������"),
                                                             new TeamLead(4, "�������� ������"),
                                                             new TeamLead(5, "�������� ���������") };

        public RandomWishlistsGeneratorTests()
        {
            wishlistsGenerator = new RandomWishlistsGenerator();
        }
        public static IEnumerable<object[]> DataForFirstTest()
        {
            yield return new object[] { juniorList, teamLeadList };
        }

        public static IEnumerable<object[]> DataForSecondTest()
        {
            yield return new object[] { new Junior(1, "���� ����"), juniorList, teamLeadList};
            yield return new object[] { new Junior(5, "����� �������"), juniorList, teamLeadList };
        }
        public static IEnumerable<object[]> DataForThirdTest()
        {
            yield return new object[] { new TeamLead(1, "��������� ������"), juniorList, teamLeadList };
            yield return new object[] { new TeamLead(5, "�������� ���������"), juniorList, teamLeadList };
        }

        [Theory]
        [MemberData(nameof(DataForFirstTest))]
        public void MakeWishlists_SizeOfTheListShouldMatchTheNumberOfTeamMembers(List<Junior> _juniors, List<TeamLead> _teamLeads)
        {
            //Arrange

            //Act
            wishlistsGenerator.MakeWishlists(_juniors, _teamLeads);

            //Assert
            int expectedJuniorsCount = _juniors.Count;
            int expectedTeamLeadsCount = _teamLeads.Count;
            foreach (Junior junior in _juniors)
            {
                Assert.Equal(expectedTeamLeadsCount, junior.Wishlist.Count);
            }
            foreach (TeamLead teamLead in _teamLeads)
            {
                Assert.Equal(expectedJuniorsCount, teamLead.Wishlist.Count);
            }
        }

        [Theory]
        [MemberData(nameof(DataForSecondTest))]
        public void MakeWishlists_JuniorShouldBeInTheTeamLeadsLists(Junior junior, List<Junior> _juniors, List<TeamLead> _teamLeads)
        {
            //Arrange

            //Act
            wishlistsGenerator.MakeWishlists(_juniors, _teamLeads);

            //Assert
            foreach (TeamLead teamLead in _teamLeads)
            {
                Assert.Contains(junior, teamLead.Wishlist);
            }
        }

        [Theory]
        [MemberData(nameof(DataForThirdTest))]
        public void MakeWishlists_TeamLeadShouldBeInTheJuniorsLists(TeamLead teamLead, List<Junior> _juniors, List<TeamLead> _teamLeads)
        {
            //Arrange

            //Act
            wishlistsGenerator.MakeWishlists(_juniors, _teamLeads);

            //Assert
            foreach (Junior junior in _juniors)
            {
                Assert.Contains(teamLead, junior.Wishlist);
            }
        }


    }
}
