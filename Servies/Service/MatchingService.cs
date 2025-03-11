using Repository.Entities;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
public  class MatchingService:IMatching
    {
        private readonly CandidateRepository _candidateRepository;

        public MatchingService(CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public  double CalculateMatchScore(Candidate c1, Candidate c2)
        {


            double score = 0;

            // 1. התאמה מגזרית (Sector ו-SubSector)
            if (c1.Sector == c2.Sector) score += 10;
            if (c1.SubSector == c2.SubSector) score += 5;

            // 2. התאמת פתיחות (Openness)
            int opennessDiff = Math.Abs((int)c1.Openness - (int)c2.Openness);
            score += (10 - opennessDiff) * 2; // ככל שההבדל קטן יותר, הציון גבוה יותר

            // 3. התאמה בסגנון לבוש (ClothingStyle)
            if (c1.ClothingStyle == c2.ClothingStyle) score += 7;

            // 4. התאמה בגובה (Height) - מבוסס על מרחק אוקלידי
            double heightDifference = Math.Abs((double)c1.Height - (double)c2.Height);
            score += Math.Max(0, (10 - heightDifference)); // גובה קרוב מוסיף נקודות

            // 5. התאמה במבנה גוף (Physique)
            if (c1.Physique == c2.Physique) score += 5;

            // 6. התאמה בצבע עור (SkinTone) וצבע שיער (HairColor)
            if (c1.SkinTone == c2.SkinTone) score += 5;
            if (c1.HairColor == c2.HairColor) score += 3;

            // 7. התאמה בהורים וסגנון משפחה
            if (c1.ParentalStatus == c2.ParentalStatus) score += 5;
            if (c1.FamilyStyle == c2.FamilyStyle) score += 7;
            if (c1.FamilyOpenness == c2.FamilyOpenness) score += 6;

            // 8. התאמה בסוג הטלפון (CellPhone)
            if (c1.CellPhone == c2.CellPhone) score += 4;

            // 9. האם יש רישיון נהיגה (License)
            if (c1.License == c2.License) score += 3;

            // 10. התאמה במקצוע (Profession)
            if (c1.ProfessionId == c2.ProfessionId) score += 8;

            // 11. התאמה בהרגלי עישון (Smoker)
            if (c1.Smoker == c2.Smoker) score += 3;

            // 12. התאמת זקן (רלוונטי לגברים בלבד)
            if (c1.Beard == c2.Beard) score += 3;

            // **נורמליזציה** - מביאים את הציון לטווח 0-100
            return Math.Min(score, 100);
        }


        public List<(Candidate, Candidate, double)> GetBestMatches()
        {
            var candidates = _candidateRepository.GetAll();
            var matches = new List<(Candidate, Candidate, double)>();

            for (int i = 0; i < candidates.Count; i++)
            {
                for (int j = i + 1; j < candidates.Count; j++)
                {
                    double score = CalculateMatchScore(candidates[i], candidates[j]);
                    matches.Add((candidates[i], candidates[j], score));
                }
            }

            // ממיינים מהתאמה הכי גבוהה לנמוכה
            return matches.OrderByDescending(m => m.Item3).ToList();
        }
    }
}


