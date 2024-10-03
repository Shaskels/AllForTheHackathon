using AllForTheHackathon.Domain;

namespace AllForTheHackathonTests
{

    public class HRDirectorTests
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new List<Team> { new Team(null, 5, null, 5),
                                                         new Team(null, 5, null, 5),
                                                         new Team(null, 5, null, 5),
                                                         new Team(null, 5, null, 5),
                                                         new Team(null, 5, null, 5) } ,
                                                                    5.0
            };
            yield return new object[] { new List<Team> { new Team(null, 3, null, 2),
                                                         new Team(null, 1, null, 1),
                                                         new Team(null, 2, null, 3) } ,
                                                                    1.6364
            };
            yield return new object[] { new List<Team> { new Team(null, 2, null, 6) },
                                                                    3.0
            };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateTheHarmonicMean_HarmonicMeanShouldBeAlwaysRight(List<Team> teams, double expected)
        {
            //Arrange
            HRDirector hRDirector = new HRDirector();

            //Act
            double res = hRDirector.CalculateTheHarmonicMean(teams);

            //Assert
            Assert.Equal(expected, Math.Round(res, 4));
        }


    }
}
