using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class ExtensionRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Brother>, BrothersRepository>();
            services.AddScoped<IRepository<Candidate>, CandidateRepository>();
            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<IRepository<History>, HistoriesRepository>();
            services.AddScoped<IRepository<Inquiries>, InquiriesRepository>();
            services.AddScoped<IRepository<Matchmaker>, MatchmakersRepository>();
            services.AddScoped<IRepository<Profession>, ProfessionsRepository>();

            return services;
        }
    }
}
