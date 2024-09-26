using AllForTheHackathon;

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
                                                                    5.0M
            };
            yield return new object[] { new List<Team> { new Team(null, 3, null, 2),
                                                         new Team(null, 1, null, 1),
                                                         new Team(null, 2, null, 3) } ,
                                                                    1.6364M
            };
            yield return new object[] { new List<Team> { new Team(null, 2, null, 6) },
                                                                    3.0M
            };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateTheHarmonicMean_HarmonicMeanShouldBeAlwaysRight(List<Team> teams, decimal expected)
        {
            HRDirector hRDirector = new HRDirector();
            decimal res = hRDirector.CalculateTheHarmonicMean(teams);
            Assert.Equal(expected, Math.Round(res, 4));
        }

        
    }
}
