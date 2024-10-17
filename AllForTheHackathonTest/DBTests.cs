using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathonTests
{
    public class DBTests : IClassFixture<ConnectionFactory>
    {

        private ApplicationContext _context;

        public DBTests(ConnectionFactory connection) 
        {
            _context = connection.context;
        }

        [Fact]
        public void Add_Without_Relation()
        {
            // Arrange
            ISaver saver = new DBSaver(_context);
            var hackathon = new Hackathon() { Result = 5 };

            //Act
            saver.SaveHackathon(hackathon);
            _context.SaveChanges();

            //Assert
            var hackathonsCount = _context.Hackathons.Count();
            Assert.Equal(2, hackathonsCount);

            var singleHackathon = _context.Hackathons.Find(2);
            Assert.Equal(5, singleHackathon.Result);

        }

        [Fact]
        public void Add_With_Relation()
        {
            // Arrange
            ISaver saver = new DBSaver(_context);
            var juniors = new List<Junior> { new Junior(1, "Юдин Адам") };
            var teamLeads = new List<TeamLead> { new TeamLead(1, "Филиппова Ульяна") };
            var teams = new List<Team> { new Team(juniors[0], 1, teamLeads[0], 1) };
            var hackathon = new Hackathon() { Juniors = juniors, TeamLeads = teamLeads,
                Teams = teams, Result = 5 };

            //Act
            saver.SaveHackathon(hackathon);
            _context.SaveChanges();

            //Assert
            var hackathonsCount = _context.Hackathons.Count();
            Assert.Equal(3, hackathonsCount);

            var singleHackathon = _context.Hackathons.Find(3);
            Assert.Equal(5, singleHackathon.Result);
            Assert.Equal(juniors, singleHackathon.Juniors);
            Assert.Equal(teamLeads, singleHackathon.TeamLeads);
            Assert.Equal(teams, singleHackathon.Teams);
        }

        [Fact]
        public void Read_Hackathon_From_BD()
        {
            // Arrange
            ISaver saver = new DBSaver(_context);
            var juniors = new List<Junior> { new Junior(1, "Юдин Адам") };
            var teamLeads = new List<TeamLead> { new TeamLead(1, "Филиппова Ульяна") };
            var teams = new List<Team> { new Team(juniors[0], 1, teamLeads[0], 1) };
            var hackathon = new Hackathon()
            {
                Juniors = juniors,
                TeamLeads = teamLeads,
                Teams = teams,
                Result = 5
            };

            //Act
            saver.SaveHackathon(hackathon);
            _context.SaveChanges();

            //Assert
            var hackathonsCount = _context.Hackathons.Count();
            Assert.Equal(1, hackathonsCount);

            var singleHackathon = _context.Hackathons.Find(1);
            Assert.Equal(5, singleHackathon.Result);
            Assert.Equal(juniors, singleHackathon.Juniors);
            Assert.Equal(teamLeads, singleHackathon.TeamLeads);
            Assert.Equal(teams, singleHackathon.Teams);
        }

        [Fact]
        public void Task_Calculating_The_Average()
        {
            // Arrange
            var hrDirector = new HRDirector();
            var hackathon1 = new Hackathon(){ Result = 5 };
            var hackathon2 = new Hackathon(){ Result = 3 };
            var hackathon3 = new Hackathon(){ Result = 4 };
            var hackathon4 = new Hackathon(){ Result = 2 };
            var hackathon5 = new Hackathon(){ Result = 1 };
            var expected = 3.75;
            _context.Hackathons.Add(hackathon1);
            _context.Hackathons.Add(hackathon2);
            _context.Hackathons.Add(hackathon3);
            _context.Hackathons.Add(hackathon4);
            _context.Hackathons.Add(hackathon5);
            _context.SaveChanges();

            //Act
            List<Hackathon> hackathons = _context.Hackathons.ToList();
            double res = hrDirector.CalculateTheAverageValue(hackathons);

            //Assert
            Assert.Equal(expected, res);

        }
    }
}
