using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.PortableExecutable;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ReportsGeneratorEngine.Email;
using ReportsGeneratorEngine.External;
using ReportsGeneratorEngine.Logger;
using ReportsGeneratorEngine.Mediator;
using ReportsGeneratorEngine.RabbitMQ;

namespace ReportsGeneratorEngine
{
    public partial class Program
    {
        static string HR = new string('-', 50);

        static void Main(string[] args)
        {
            var services = ConfigureServices(args);
            var serviceProvider = services.BuildServiceProvider();
            
            Console.Clear();

            Console.WriteLine(HR);

            serviceProvider.GetService<Application>().Run();

            Console.WriteLine(HR);

            Console.WriteLine("Job fisinhed!!!");

            Console.ReadLine();
        }

        private static IServiceCollection ConfigureServices(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<Application>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IEmailService, EmailContext>();
            services.AddScoped<ILogger, LoggerContext>();
            services.AddScoped<IMediatorContext, MediatorContext>();
            services.AddScoped<ISalesforceApi, SalesforceApi>();
            services.AddScoped<IRabbitService, RabbitService>();

            services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

            return services;
        }
    }
}
