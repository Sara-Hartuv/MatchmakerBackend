using Repository.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;

namespace Service.Service
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            // מיפוי מ-Candidate ל-CandidateDto
            CreateMap<Candidate, CandidateDto>()
                .ForMember(dest => dest.Sector, src => src.MapFrom(s => s.Sector.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.SubSector, src => src.MapFrom(s => s.SubSector.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.CellPhone, src => src.MapFrom(s => s.CellPhone.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.Openness, src => src.MapFrom(s => s.Openness.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.ClothingStyle, src => src.MapFrom(s => s.ClothingStyle.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.Physique, src => src.MapFrom(s => s.Physique.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.SkinTone, src => src.MapFrom(s => s.SkinTone.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.HairColor, src => src.MapFrom(s => s.HairColor.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.HeadCovering, src => src.MapFrom(s => s.HeadCovering.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.Hat, src => src.MapFrom(s => s.Hat.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.Suit, src => src.MapFrom(s => s.Suit.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.FamilyStyle, src => src.MapFrom(s => s.FamilyStyle.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.ParentalStatus, src => src.MapFrom(s => s.ParentalStatus.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.FamilyOpenness, src => src.MapFrom(s => s.FamilyOpenness.ToString())) // המרה מ-enum ל-string
                .ForMember(dest => dest.LastStudy, src => src.MapFrom(s => s.LastStudy.ToString())); // המרה מ-enum ל-string

            // מיפוי מ-CandidateDto ל-Candidate
            CreateMap<CandidateDto, Candidate>()
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(s =>
                    s.File != null ? s.File.FileName : null));

            CreateMap<Matchmaker, MatchmakerDto>().ReverseMap();
            CreateMap<Brother, BrotherDto>().ReverseMap();
            CreateMap<Inquiries, InquiriesDto>().ReverseMap();
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

        public byte[] convertToByte(string image)
        {
            var res = System.IO.File.ReadAllBytes(image);
            return res;
        }
    }
}
