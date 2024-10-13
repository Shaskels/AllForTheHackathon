﻿using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Strategies;
using AllForTheHackathon.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AllForTheHackathon.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureHostConfiguration(options =>
            {
                options.AddJsonFile("./appsettings.json");
            }).ConfigureServices((builder, services) =>
            {
                services.AddHostedService<AppStarter>();
                services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
                services.AddDbContext<ApplicationContext>(s => s.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
                services.AddSingleton<ITeamBuildingStrategy, GaleShapleyStrategy>();
                services.AddSingleton<IWishlistsGenerator, RandomWishlistsGenerator>();
                services.AddSingleton<ISaver, DBSaver>();
                services.AddSingleton<IRegistrar, RegistrarFromCSVFiles>();
                services.AddTransient<Hackathon>();
                services.AddSingleton<HRManager>();
                services.AddSingleton<HRDirector>();
                services.AddSingleton<OneHackathonHolder>();
                services.AddSingleton<HackathonWriter>();
                services.AddSingleton<AverageCalculator>();
            }).Build();
            host.Run();
        }
    }
}
