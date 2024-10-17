using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using AllForTheHackathon.Infrastructure;
using Npgsql;
using Testcontainers.PostgreSql;

namespace AllForTheHackathonTests
{
    public class ConnectionFactory : IDisposable
    {
        private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
         .WithImage("postgres:15-alpine")
         .Build();
        private bool _disposedValue = false;
        public ApplicationContext context {  get; private set; }
        public ConnectionFactory() 
        {
            context = CreateNewContextForSQLite();
        }

        public ApplicationContext CreateNewContextForSQLite()
        {
            InitializeAsync().Wait();
            var connection = new NpgsqlConnection(_postgres.GetConnectionString());
            connection.Open();

            var option = new DbContextOptionsBuilder<ApplicationContext>().UseNpgsql(connection).Options;

            var context = new ApplicationContext(option);

            if (context != null) 
            {
                context.Database.EnsureCreated();
            }

            return context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task InitializeAsync()
        {
            await _postgres.StartAsync();
        }

        public Task DisposeAsync()
        {
            return _postgres.DisposeAsync().AsTask();
        }
    }
}
