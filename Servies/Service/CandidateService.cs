using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace Service.Service
{
    public class CandidateService:IService<CandidateDto>, IMyDetails<Candidate>
    {
        private readonly IRepository<Candidate> _repository;
        private readonly IService<City> _cityService;
        private readonly IMapper _mapper;

         public CandidateService(IRepository<Candidate> repository , IService<City> cityService, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _cityService = cityService;
        }

   
        public CandidateDto AddItem(CandidateDto item)
        {
            return _mapper.Map<CandidateDto>(_repository.AddItem(_mapper.Map<Candidate>(item)));
        }

        public void Delete(int id)
        {
            _repository.DeleteItem(id);
        }

       
        public List<CandidateDto> GetAll()
        {
            return _mapper.Map<List<CandidateDto>>(_repository.GetAll());
        }


        public CandidateDto GetById(int id)
        {
            return _mapper.Map<CandidateDto>(_repository.Get(id));
        }

        public CandidateDto Update(int id, CandidateDto item)
        {
            return _mapper.Map<CandidateDto>(_repository.UpdateItem(id, _mapper.Map<Candidate>(item)));
        }
        public Candidate[] GetFemaleCandidtes()
        {
            List<Candidate> allCandidates = _mapper.Map<List<Candidate>>(GetAll());
            List<Candidate> femaleCandidates = new List<Candidate>();

            foreach (Candidate candidate in allCandidates) {
                if (candidate.Gender == Gender.אישה)
                {
                    femaleCandidates.Add(candidate);

                }
            }
            return femaleCandidates.ToArray();
        }

        public Candidate[] GetMaleCandidtes()
        {
            List<Candidate> allCandidates = _mapper.Map<List<Candidate>>(GetAll());
            List<Candidate> maleCandidates = new List<Candidate>();

            foreach (Candidate candidate in allCandidates)
            {
                if (candidate.Gender == Gender.גבר)
                {
                    maleCandidates.Add(candidate);

                }
            }
            return maleCandidates.ToArray();
        }


        public int CalculateAge(DateTime? birthDate)
        {
            if (!birthDate.HasValue)
                return 0; // או כל ערך ברירת מחדל שמתאים לך

            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Value.Year;

            // בדיקה אם יום ההולדת כבר עבר השנה
            if (birthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        public string GetGeneralCandidateInfo(Candidate candidate)
        {
            if (candidate == null)
                return "פרטי המועמד אינם זמינים";

            StringBuilder generalInfo = new StringBuilder();


            generalInfo.AppendLine($"גיל: {CalculateAge(candidate.BornDate)}");
            City city = _cityService.GetById(candidate.CityId ?? 28);
            generalInfo.AppendLine($"עיר: {city.Name}");
            generalInfo.AppendLine($"מגזר: {candidate.Sector}");
            generalInfo.AppendLine($"תת מגזר: {candidate.SubSector}");
            generalInfo.AppendLine($"פתיחות: {candidate.Openness}");
            generalInfo.AppendLine($"סגנון לבוש: {candidate.ClothingStyle}");
            if (candidate.Gender == Gender.גבר)
            {
                generalInfo.AppendLine($"רישיון נהיגה: {(candidate.License == true ? "כן" : "לא")}");
            }
            generalInfo.AppendLine($"סוג טלפון: {candidate.CellPhone} ");
            generalInfo.AppendLine($"גובה: {candidate.Height} סמ");

            generalInfo.AppendLine($"מבנה : {candidate.Physique}");
            generalInfo.AppendLine($"צבע עור: {candidate.SkinTone}");
            generalInfo.AppendLine($"צבע שיער: {candidate.HairColor}");
            if (candidate.Gender == Gender.אישה)
            {
                generalInfo.AppendLine($"סוג לימודים אחרון: {candidate.LastStudy}");
                generalInfo.AppendLine($"שם מוסד לימודים: {candidate.StudyName}");
                generalInfo.AppendLine($"מקצוע: {candidate.profession?.Name}");
                generalInfo.AppendLine($"מקום עבודה: {candidate.Workplace}");
                generalInfo.AppendLine($"כיסוי ראש: {candidate.HeadCovering}");
            }
            else
            {
                generalInfo.AppendLine($"כובע: {candidate.Hat}");
                generalInfo.AppendLine($"חליפה: {candidate.Suit}");
                generalInfo.AppendLine($"זקן: {(candidate.Beard == true ? "כן" : "לא")}");
                generalInfo.AppendLine($"מעשן: {(candidate.Smoker == true ? "כן" : "לא")}");
            }
            generalInfo.AppendLine($"סגנון משפחתי: {candidate.FamilyStyle}");
            generalInfo.AppendLine($"מצב הורים: {candidate.ParentalStatus}");
            generalInfo.AppendLine($"שם האב: {candidate.FatherName}");
            generalInfo.AppendLine($"עיסוק האב: {candidate.FatherOccupation}");
            generalInfo.AppendLine($"שם האם: {candidate.MotherName}");
            generalInfo.AppendLine($"עיסוק האם: {candidate.MotherOccupation}");
            generalInfo.AppendLine($"פתיחות משפחתית: {candidate.FamilyOpenness}");

            return generalInfo.ToString();
        }
        public string GetAllCandidateInfo(Candidate candidate)
        {
            if (candidate == null)
                return "פרטי המועמד אינם זמינים";

            StringBuilder generalInfo = new StringBuilder();

            generalInfo.AppendLine($"שם: {candidate.FirstName+ " "+candidate.LastName}");
            generalInfo.AppendLine($"גיל: {CalculateAge(candidate.BornDate)}");
            generalInfo.AppendLine($"כתובת: {candidate.Adress}");
            City city = _cityService.GetById(candidate.CityId ?? 28);
            generalInfo.AppendLine($"עיר: {city.Name}");
            generalInfo.AppendLine($"מגזר: {candidate.Sector}");
            generalInfo.AppendLine($"תת מגזר: {candidate.SubSector}");
            generalInfo.AppendLine($"פתיחות: {candidate.Openness}");
            generalInfo.AppendLine($"סגנון לבוש: {candidate.ClothingStyle}");
            generalInfo.AppendLine($"תאור: {candidate.Description}");
            if (candidate.Gender == Gender.גבר)
            {
                generalInfo.AppendLine($"רישיון נהיגה: {(candidate.License == true ? "כן" : "לא")}");
            }
            generalInfo.AppendLine($"סוג טלפון: {candidate.CellPhone} ");
            generalInfo.AppendLine($"גובה: {candidate.Height} סמ");

            generalInfo.AppendLine($"מבנה : {candidate.Physique}");
            generalInfo.AppendLine($"צבע עור: {candidate.SkinTone}");
            generalInfo.AppendLine($"צבע שיער: {candidate.HairColor}");
            if (candidate.Gender == Gender.אישה)
            {
                generalInfo.AppendLine($"סוג לימודים אחרון: {candidate.LastStudy}");
                generalInfo.AppendLine($"שם מוסד לימודים: {candidate.StudyName}");
                generalInfo.AppendLine($"מקצוע: {candidate.profession?.Name}");
                generalInfo.AppendLine($"מקום עבודה: {candidate.Workplace}");
                generalInfo.AppendLine($"כיסוי ראש: {candidate.HeadCovering}");
            }
            else
            {
                generalInfo.AppendLine($"כובע: {candidate.Hat}");
                generalInfo.AppendLine($"חליפה: {candidate.Suit}");
                generalInfo.AppendLine($"זקן: {(candidate.Beard == true ? "כן" : "לא")}");
                generalInfo.AppendLine($"מעשן: {(candidate.Smoker == true ? "כן" : "לא")}");
            }
            generalInfo.AppendLine($"סגנון משפחתי: {candidate.FamilyStyle}");
            generalInfo.AppendLine($"מצב הורים: {candidate.ParentalStatus}");
            generalInfo.AppendLine($"שם האב: {candidate.FatherName}");
            generalInfo.AppendLine($"עיסוק האב: {candidate.FatherOccupation}");
            generalInfo.AppendLine($"שם האם: {candidate.MotherName}");
            generalInfo.AppendLine($"עיסוק האם: {candidate.MotherOccupation}");
            generalInfo.AppendLine($"פתיחות משפחתית: {candidate.FamilyOpenness}");
            generalInfo.AppendLine($"מחפש: {candidate.DescriptionFind}");


            return generalInfo.ToString();
        }
    }
}
