using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Repositories;
using Service.Interfaces;
using Service.Dtos;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IRegistrationAndLogin<User>, RegistrationAndLoginService>();
            services.AddScoped<IHungarianAlgorithm, HungarianAlgorithmService>();
            services.AddScoped<IService<CandidateDto>, CandidateService>();
            services.AddScoped<IService<BrotherDto>, BrotherService>();
            services.AddScoped<IService<City>, CityService>();
            services.AddScoped<IService<MatchDto>, MatchService>();
            services.AddScoped<IService<InquiriesDto>, InquiriesService>();
            services.AddScoped<IService<MatchmakerDto>, MatchmakerService>();
            services.AddScoped<IService<Profession>, ProfessionService>();
            services.AddScoped<IMyDetails<Candidate>, CandidateService>();
            services.AddScoped<IServiceMatch, MatchService>();
            services.AddScoped<IEmailService, SmtpEmailService>();
            services.AddAutoMapper(typeof(MyMapper));
            return services;
        }
    }
}

