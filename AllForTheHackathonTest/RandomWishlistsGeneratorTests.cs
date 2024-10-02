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
            yield return new object[] { new Employee(1, "���� ����"), juniorList, teamLeadList};
            yield return new object[] { new Employee(5, "����� �������"), juniorList, teamLeadList };
        }
        public static IEnumerable<object[]> DataForThirdTest()
        {
            yield return new object[] { new Employee(1, "��������� ������"), juniorList, teamLeadList };
            yield return new object[] { new Employee(5, "�������� ���������"), juniorList, teamLeadList };
        }

        [Theory]
        [MemberData(nameof(DataForFirstTest))]
        public void MakeWishlists_SizeOfTheListShouldMatchTheNumberOfTeamMembers(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            //Arrange

            //Act
            List<Wishlist> juniorsWishlists = wishlistsGenerator.MakeWishlistsForJuniors(juniors, teamLeads);
            List<Wishlist> teamLeadsWishlists = wishlistsGenerator.MakeWishlistsForTeamLeads(juniors, teamLeads);

            //Assert
            int expectedJuniorsCount = juniors.Count;
            int expectedTeamLeadsCount = teamLeads.Count;
            foreach (Wishlist wishlist in juniorsWishlists)
            {
                Assert.Equal(expectedTeamLeadsCount, wishlist.Employees.Count);
            }
            foreach (Wishlist wishlist in teamLeadsWishlists)
            {
                Assert.Equal(expectedJuniorsCount, wishlist.Employees.Count);
            }
        }

        [Theory]
        [MemberData(nameof(DataForSecondTest))]
        public void MakeWishlists_JuniorShouldBeInTheTeamLeadsLists(Employee junior, List<Junior> juniors, List<TeamLead> teamLeads)
        {
            //Arrange

            //Act
            List<Wishlist> teamLeadsWishlists = wishlistsGenerator.MakeWishlistsForTeamLeads(juniors, teamLeads);

            //Assert
            foreach (Wishlist wishlist in teamLeadsWishlists)
            {
                Assert.Contains(junior, wishlist.Employees);
            }
        }

        [Theory]
        [MemberData(nameof(DataForThirdTest))]
        public void MakeWishlists_TeamLeadShouldBeInTheJuniorsLists(Employee teamLead, List<Junior> juniors, List<TeamLead> teamLeads)
        {
            //Arrange

            //Act
            List<Wishlist> juniorsWishlists = wishlistsGenerator.MakeWishlistsForJuniors(juniors, teamLeads);

            //Assert
            foreach (Wishlist wishlist in juniorsWishlists)
            {
                Assert.Contains(teamLead, wishlist.Employees);
            }
        }


    }
}
