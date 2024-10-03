using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathonTests
{
    public class DBTests
    {
        [Fact]
        public void Task_Add_Without_Relation()
        {
            // Arrange
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();
            var hackathon = new Hackathon() { Result = 5 };

            //Act
            var data = context.Hackathons.Add(hackathon);
            context.SaveChanges();

            //Assert
            var hackathonsCount = context.Hackathons.Count();
            if (hackathonsCount != 0)
            {
                Assert.Equal(1, hackathonsCount);
            }

            var singleHackathon = context.Hackathons.FirstOrDefault();
            if (singleHackathon != null)
            {
                Assert.Equal(5, singleHackathon.Result);
            }
        }

        [Fact]
        public void Task_Add_With_Relation()
        {
            // Arrange
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();
            var juniors = new List<Junior> { new Junior(1, "Юдин Адам") };
            var teamLeads = new List<TeamLead> { new TeamLead(1, "Филиппова Ульяна") };
            var teams = new List<Team> { new Team(juniors[0], 1, teamLeads[0], 1) };
            var hackathon = new Hackathon() { Juniors = juniors, TeamLeads = teamLeads,
                Teams = teams, Result = 5 };

            //Act
            var data = context.Hackathons.Add(hackathon);
            context.SaveChanges();

            //Assert
            var hackathonsCount = context.Hackathons.Count();
            if (hackathonsCount != 0)
            {
                Assert.Equal(1, hackathonsCount);
            }

            var singleHackathon = context.Hackathons.FirstOrDefault();
            if (singleHackathon != null)
            {
                Assert.Equal(5, singleHackathon.Result);
                Assert.Equal(juniors, singleHackathon.Juniors);
                Assert.Equal(teamLeads, singleHackathon.TeamLeads);
                Assert.Equal(teams, singleHackathon.Teams);
            }
        }

        [Fact]
        public void Task_Calculating_The_Average()
        {
            // Arrange
            var factory = new ConnectionFactory();
            var hrDirector = new HRDirector();
            var context = factory.CreateContextForSQLite();
            var hackathon1 = new Hackathon(){ Result = 5 };
            var hackathon2 = new Hackathon(){ Result = 3 };
            var hackathon3 = new Hackathon(){ Result = 4 };
            var hackathon4 = new Hackathon(){ Result = 2 };
            var hackathon5 = new Hackathon(){ Result = 1 };
            var expected = 3.0;
            context.Hackathons.Add(hackathon1);
            context.Hackathons.Add(hackathon2);
            context.Hackathons.Add(hackathon3);
            context.Hackathons.Add(hackathon4);
            context.Hackathons.Add(hackathon5);
            context.SaveChanges();

            //Act
            var hackathons = context.Hackathons.ToList();
            var res = hrDirector.CalculateTheAverageValue(hackathons);

            //Assert
            Assert.Equal(expected, res);

        }
    }
}
