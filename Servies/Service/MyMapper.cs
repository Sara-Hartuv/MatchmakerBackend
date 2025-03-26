using Repository.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Service.Service
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Candidate, CandidateDto>().ForMember(dest => dest.Image, src => src.MapFrom(s =>
               File.Exists(Environment.CurrentDirectory + "/Images/" + s.ImageUrl)
               ? convertToByte(Environment.CurrentDirectory + "/Images/" + s.ImageUrl)
               : null));

            CreateMap<CandidateDto, Candidate>()
                    .ForMember(dest => dest.ImageUrl, src => src.MapFrom(s =>
                        s.File != null ? s.File.FileName : null));
            CreateMap<Matchmaker, MatchmakerDto>().ReverseMap();
            CreateMap<Brother, BrotherDto>().ReverseMap();
            CreateMap<Inquiries, InquiriesDto>().ReverseMap();
            CreateMap<Match, MatchDto>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.IdCandidateGirl, opt => opt.MapFrom(src => src.IdCandidateGirl))
         .ForMember(dest => dest.IdCandidateGuy, opt => opt.MapFrom(src => src.IdCandidateGuy))
         .ForMember(dest => dest.IdMatchmaker, opt => opt.MapFrom(src => src.IdMatchmaker))
         .ForMember(dest => dest.IsEngaged, opt => opt.MapFrom(src => src.IsEngaged))
         .ForMember(dest => dest.ConfirmationGirl, opt => opt.MapFrom(src => src.ConfirmationGirl))
         .ForMember(dest => dest.ConfirmationGuy, opt => opt.MapFrom(src => src.ConfirmationGuy))
         .ForMember(dest => dest.DateMatch, opt => opt.MapFrom(src => src.DateMatch))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
         .ForAllOtherMembers(opt => opt.Ignore()); // מתעלם מכל שאר השדות שלא ממופים
            CreateMap<User, UserDto>().ReverseMap();


        }
        public byte[] convertToByte(string image)
        {
            var res = System.IO.File.ReadAllBytes(image);
            return res;
        }
    }
}
