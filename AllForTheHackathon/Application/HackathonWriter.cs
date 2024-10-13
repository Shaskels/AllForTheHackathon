using AllForTheHackathon.Domain;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathon.Application
{
    public class HackathonWriter
    {
        ApplicationContext _context;
        public HackathonWriter(ApplicationContext context) 
        {
            _context = context;
        }
        public void WriteLineHackathon(Settings settings)
        {
            Hackathon? hackathon = _context.Hackathons.Find(settings.HackathonId);
            if (hackathon != null)
            {
                Console.WriteLine(hackathon);
            }
        }
    }
}
