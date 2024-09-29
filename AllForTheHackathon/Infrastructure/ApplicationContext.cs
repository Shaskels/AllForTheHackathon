using Microsoft.EntityFrameworkCore;

namespace AllForTheHackathon.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
        }
    }
}
