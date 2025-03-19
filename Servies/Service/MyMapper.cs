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
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<List<Match>, List<MatchDto>>().ReverseMap();


        }
        public byte[] convertToByte(string image)
        {
            var res = System.IO.File.ReadAllBytes(image);
            return res;
        }
    }
}
