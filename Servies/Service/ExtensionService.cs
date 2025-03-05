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
using MatchmakerDto = Service.Dtos.MatchmakerDto;

namespace Service.Service
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IService<CandidateDto>, CandidateService>();
            services.AddScoped<IService<Brother>, BrotherService>();
            services.AddScoped<IService<City>, CityService>();
            services.AddScoped<IService<History>, HistoryService>();
            services.AddScoped<IService<Inquiries>, InquiriesService>();
            services.AddScoped<IService<MatchmakerDto>, MatchmakerService>();
            services.AddScoped<IService<Profession>, ProfessionService>();
            services.AddAutoMapper(typeof(MyMapper));
            return services;
        }
    }
}

