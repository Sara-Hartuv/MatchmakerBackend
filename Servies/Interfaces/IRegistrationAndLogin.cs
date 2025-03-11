using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRegistrationAndLogin<T>
    {
        List<T> GetAllCandidates();
        List<T> GetAllMachmaker();
        T GetById(int id);

        T AddItem(T item, string userType);
        T Update(int id, T item);
        void Delete(int id);
        string Generate(User user);
        User Authenticate(string email, string password, string userType);
        User Authenticate(string email, string password);
    }
}
