using AllForTheHackathon.Domain;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathon.Application
{
    public class AverageCalculator
    {
        private ApplicationContext _context;
        private HRDirector _hrDirector;
        public AverageCalculator(ApplicationContext context, HRDirector hRDirector) 
        {
            _context = context;
            _hrDirector = hRDirector;   
        }
        public void AverageForAllHackathons()
        {
            List<Hackathon> hackathons = _context.Hackathons.ToList();
            double average = _hrDirector.CalculateTheAverageValue(hackathons);
            Console.WriteLine($"{hackathons.Count} hackathons found");
            Console.WriteLine($"Average mean: {average}");
        }
    }
}
