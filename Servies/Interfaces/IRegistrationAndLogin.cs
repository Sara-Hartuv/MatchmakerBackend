using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    // ממשק להתחברות והרשמה 
    public interface IRegistrationAndLogin<T>
    {
        List<T> GetAllCandidates();
        List<T> GetAllMachmaker();
        string Generate(User user);
        T AddItem(T t, string userType);
        User Authenticate(string email, string password, string userType);
        User Authenticate(string email, string password);
    }
}
