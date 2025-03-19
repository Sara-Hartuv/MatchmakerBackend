using Microsoft.AspNetCore.Http;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos
{
    public class CandidateDto : UserDto
    {
        public int Id { get; set; }
        public Sector Sector { get; set; }//מגזר
        public SubSector SubSector { get; set; }//תת מגזר
        public int GivesMoney { get; set; }
        public int AskingMoney { get; set; }
        public CellPhone CellPhone { get; set; }
        public Openness Openness { get; set; }//פתיחות
        public ClothingStyle ClothingStyle { get; set; }//סגנון לבוש
        public bool License { get; set; }//רשיון
        public double Height { get; set; }//גובה
        public Physique Physique { get; set; }//מבנה גוף
        public SkinTone SkinTone { get; set; }//צבע עור
        public HairColor HairColor { get; set; }//צבע שיער

        public StudtyType LastStudy { get; set; }//מקום לימודים
        public string StudyName { get; set; }
        public Profession profession { get; set; }//מקצוע
        public string Workplace { get; set; }//מקום עבודה
        public string Description { get; set; }//תאור
        public HeadCovering HeadCovering { get; set; }
        public Hat Hat { get; set; }
        public Suit Suit { get; set; }
        public bool Beard { get; set; }//זקן
        public bool Smoker { get; set; }

        //פרטי משפחה
        public FamilyStyle FamilyStyle { get; set; }//סגנון משפחה
        public ParentalStatus ParentalStatus { get; set; }//מצב ההורים
        public FamilyOpenness FamilyOpenness { get; set; }//רמת פתיחות
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string NameFromHome { get; set; }
        public string MotherOccupation { get; set; }
        //אחים ואחיות
        public List<BrotherDto> Brothers { get; set; }
        public string DescriptionFind { get; set; }
        public List<InquiriesDto> Inquiries { get; set; }//טלפונים לבירורים
        public byte[]? Image { get; set; }
        public IFormFile? File { get; set; }
        public bool Status { get; set; }
    }
}
