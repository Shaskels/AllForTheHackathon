using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathonTests
{
    public class ConnectionFactory : IDisposable
    {
        private bool disposedValue = false;

        public ApplicationContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<ApplicationContext>().UseSqlite(connection).Options;

            var context = new ApplicationContext(option);

            return context;
        }

        public ApplicationContext CreateNewContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<ApplicationContext>().UseSqlite(connection).Options;

            var context = new ApplicationContext(option);

            if (context != null) 
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
