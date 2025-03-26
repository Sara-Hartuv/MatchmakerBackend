using Repository.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using HungarianAlgorithm;
using System;
using System.Linq;
using Service.Dtos;
using AutoMapper;

namespace Service.Service
{
    public class HungarianAlgorithmService : IHungarianAlgorithm
    {
        private readonly IMyDetails<Candidate> _candidateService;
        private readonly IService<MatchDto> _matchService;
        private readonly IMapper _mapper;
        private Candidate[] femaleCandidates;
        private Candidate[] maleCandidates;
        private int maleCount, femaleCount;
        public int[,] CostMatrix { get; set; }
        public int[,] CostMatrixMale { get; set; }
        public int[,] CostMatrixFemale { get; set; }
        private int[] assignments;
        private static Random _random;


        public HungarianAlgorithmService(IMyDetails<Candidate> candidateService, IService<MatchDto> matchService, IMapper mapper)
        {
            _candidateService = candidateService;
            _matchService = matchService;
            _mapper = mapper;
            femaleCandidates = _candidateService.GetFemaleCandidtes();
            maleCandidates = _candidateService.GetMaleCandidtes();
            femaleCount = femaleCandidates.Length;
            maleCount = maleCandidates.Length;
            CostMatrix = new int[maleCount, femaleCount];
            CostMatrixMale = new int[ Math.Min( 10, maleCount), femaleCount];
            CostMatrixFemale = new int[maleCount, Math.Min(10, femaleCount)];
            _random = new Random();
        }

        public int CalculateMatchScore(Candidate c1, Candidate c2)
        {
            int score = 0;
            
            if (c1.Sector == c2.Sector) score += 10;
            if (c1.SubSector == c2.SubSector) score += 5;
            int opennessDiff = Math.Abs((int)c1.Openness - (int)c2.Openness);
            score += (6 - opennessDiff) * 3;
            int clothingStyleDiff = Math.Abs((int)c1.ClothingStyle - (int)c2.ClothingStyle);
            score += (5 - clothingStyleDiff) * 2;
            // שימוש בלוגריתם כדי לא לתת לגובה הרבה ניקוד
            double heightDifference = Math.Abs((double)c1.Height - (double)c2.Height);
            score += (int) (5 / (1 + Math.Log(1 + heightDifference)));
            int PhysiqueDiff = Math.Abs((int)c1.Physique - (int)c2.Physique);
            score += (3 - PhysiqueDiff) * 2;
            int SkinToneDiff = Math.Abs((int)c1.SkinTone - (int)c2.SkinTone);
            score += (4 - PhysiqueDiff) ;
            // haircolor - לא משפיע
            if (c1.ParentalStatus == c2.ParentalStatus) score += 10;
            int FamilyStyleDiff = Math.Abs((int)c1.FamilyStyle - (int)c2.FamilyStyle);
            score += (3 - FamilyStyleDiff) * 3;
            if (c1.FamilyOpenness == c2.FamilyOpenness) score += 6;
            if (c1.CellPhone == c2.CellPhone) score += 4;
            if (c1.License == c2.License) score += 3;
            if (c1.ProfessionId == c2.ProfessionId) score += 8;
            if (c1.Smoker == c2.Smoker) score += 3;
            if (c1.Beard == c2.Beard) score += 3;
            Match m = _mapper.Map<List<Match>>(_matchService.GetAll()).FirstOrDefault(m => (m.guy.Equals(c1) && m.girl.Equals(c2)) || (m.guy.Equals(c2) && m.girl.Equals(c1)));
            if (m != null)
            {
                if (DateTime.Today.Year - m.DateMatch.Year < 1)//הצעה פעמים
                {
                    score = 0;
                }
            }
            else
                score += 5;//אף פעם לא הציעו את ההצעה
            if (c1.Brothers.FirstOrDefault(x => x.NumId == c2.NumId) != null)//אחים
            {
                score = 0;
            }
            
            return Math.Min(score, 100);
        }

        public static void ShuffleCandidates(Candidate[] candidates)
        {
            for (int i = candidates.Length - 1; i > 0; i--)
            {
                int j = _random.Next(0, i + 1);
                (candidates[i], candidates[j]) = (candidates[j], candidates[i]);
            }
        }

        public void MatrixFilling(int[,] costMatrix)
        {
            for (int i = 0; i < costMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.GetLength(1); j++)
                {
                    double score = CalculateMatchScore(maleCandidates[i], femaleCandidates[j]);
                    costMatrix[i, j] = (int)(100 - score);
                }
            }
            ShuffleCandidates(femaleCandidates);
            ShuffleCandidates(maleCandidates);
        }

        public (Candidate[,], int[]) RunHungarianAlgorithm(int[,] costMatrix)
        {
            assignments = costMatrix.FindAssignments();
            Candidate[,] idAssignments = new Candidate[assignments.Length, 2];
            int[] costMatch = new int[assignments.Length];
            for (int i = 0; i < assignments.Length; i++)
            {
                if (assignments[i] != -1)
                {
                    idAssignments[i, 0] = maleCandidates[i];
                    idAssignments[i, 1] = femaleCandidates[assignments[i]];
                    costMatch[i] = 100 - costMatrix[i, assignments[i]];
                }
                else
                {
                    idAssignments[i, 0] = maleCandidates[i];
                    idAssignments[i, 1] = null;
                }
            }
            return (idAssignments, costMatch);
        }

    }


}
