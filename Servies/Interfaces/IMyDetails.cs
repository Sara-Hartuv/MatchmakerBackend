using Repository.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public  interface IMyDetails<T>
    {
        // ממשק עבור מועמדים
        string GetGeneralCandidateInfo(Candidate candidate);
        string GetAllCandidateInfo(Candidate candidate);
        T[] GetMaleCandidtes();
        T[] GetFemaleCandidtes();
    }
}
