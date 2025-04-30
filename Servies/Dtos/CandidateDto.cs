using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Service.Dtos
{
    public class CandidateDto : UserDto
    {
        public int Id { get; set; }

        // שינוי: המרת ה-Enum ל-String
        public string Sector { get; set; } // המרת ה-Sector מ-Enum ל-String
        public string SubSector { get; set; } // המרת ה-SubSector מ-Enum ל-String

        public int GivesMoney { get; set; }
        public int AskingMoney { get; set; }
        public string CellPhone { get; set; } // המרת ה-CellPhone מ-Enum ל-String
        public string Openness { get; set; } // המרת ה-Openness מ-Enum ל-String
        public string ClothingStyle { get; set; } // המרת ה-ClothingStyle מ-Enum ל-String
        public bool License { get; set; }
        public double Height { get; set; }
        public string Physique { get; set; } // המרת ה-Physique מ-Enum ל-String
        public string SkinTone { get; set; } // המרת ה-SkinTone מ-Enum ל-String
        public string HairColor { get; set; } // המרת ה-HairColor מ-Enum ל-String

        public string LastStudy { get; set; } // המרת ה-LastStudy מ-Enum ל-String
        public string StudyName { get; set; }
        public string Profession { get; set; } // המרת ה-Profession מ-Enum ל-String
        public string Workplace { get; set; }
        public string Description { get; set; }
        public string HeadCovering { get; set; } // המרת ה-HeadCovering מ-Enum ל-String
        public string Hat { get; set; } // המרת ה-Hat מ-Enum ל-String
        public string Suit { get; set; } // המרת ה-Suit מ-Enum ל-String
        public bool Beard { get; set; }
        public bool Smoker { get; set; }

        // פרטי משפחה
        public string FamilyStyle { get; set; } // המרת ה-FamilyStyle מ-Enum ל-String
        public string ParentalStatus { get; set; } // המרת ה-ParentalStatus מ-Enum ל-String
        public string FamilyOpenness { get; set; } // המרת ה-FamilyOpenness מ-Enum ל-String
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string NameFromHome { get; set; }
        public string MotherOccupation { get; set; }
        public List<BrotherDto> Brothers { get; set; }
        public string DescriptionFind { get; set; }
        public List<InquiriesDto> Inquiries { get; set; }
        public byte[]? Image { get; set; }
        public IFormFile? File { get; set; }
        public bool Status { get; set; }
    }
}
