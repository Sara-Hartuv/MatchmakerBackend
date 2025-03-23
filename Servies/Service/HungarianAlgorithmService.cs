using Repository.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using HungarianAlgorithm;
using System;
using System.Linq;

namespace Service.Service
{
    public class HungarianAlgorithmService : IHungarianAlgorithm
    {
        private readonly IMyDetails<Candidate> _candidateService;
        private Candidate[] femaleCandidates;
        private Candidate[] maleCandidates;
        private int maleCount, femaleCount;
        public int[,] CostMatrix { get; set; }
        public int[,] CostMatrixMale { get; set; }
        public int[,] CostMatrixFemale { get; set; }
        private int[] assignments;
        private static Random _random;


        public HungarianAlgorithmService(IMyDetails<Candidate> candidateService)
        {
            _candidateService = candidateService;
            femaleCandidates = _candidateService.GetFemaleCandidtes();
            maleCandidates = _candidateService.GetMaleCandidtes();
            femaleCount = femaleCandidates.Length;
            maleCount = maleCandidates.Length;
            CostMatrix = new int[maleCount, femaleCount];
            CostMatrixMale = new int[10, femaleCount];
            CostMatrixFemale = new int[maleCount, 10];
            _random = new Random();
        }

        public int CalculateMatchScore(Candidate c1, Candidate c2)
        {
            int score = 0;

            if (c1.Sector == c2.Sector) score += 10;
            if (c1.SubSector == c2.SubSector) score += 5;
            int opennessDiff = Math.Abs((int)c1.Openness - (int)c2.Openness);
            score += (10 - opennessDiff) * 2;
            if (c1.ClothingStyle == c2.ClothingStyle) score += 7;
            double heightDifference = Math.Abs((double)c1.Height - (double)c2.Height);
            score += (int)(Math.Max(0, (10 - heightDifference)));
            if (c1.Physique == c2.Physique) score += 5;
            if (c1.SkinTone == c2.SkinTone) score += 5;
            if (c1.HairColor == c2.HairColor) score += 3;
            if (c1.ParentalStatus == c2.ParentalStatus) score += 5;
            if (c1.FamilyStyle == c2.FamilyStyle) score += 7;
            if (c1.FamilyOpenness == c2.FamilyOpenness) score += 6;
            if (c1.CellPhone == c2.CellPhone) score += 4;
            if (c1.License == c2.License) score += 3;
            if (c1.ProfessionId == c2.ProfessionId) score += 8;
            if (c1.Smoker == c2.Smoker) score += 3;
            if (c1.Beard == c2.Beard) score += 3;

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

        public Candidate[,] RunHungarianAlgorithm(int[,] costMatrix)
        {
            assignments = costMatrix.FindAssignments();
            Candidate[,] idAssignments = new Candidate[assignments.Length, 2];
            for (int i = 0; i < assignments.Length; i++)
            {
                if (assignments[i] != -1)
                {
                    idAssignments[i, 0] = maleCandidates[i];
                    idAssignments[i, 1] = femaleCandidates[assignments[i]];
                }
                else
                {
                    idAssignments[i, 0] = maleCandidates[i];
                    idAssignments[i, 1] = null;
                }
            }
            return idAssignments;
        }

    }


}
