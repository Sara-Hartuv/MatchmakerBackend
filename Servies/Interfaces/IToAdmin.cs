using Repository.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{

    // ממשק עבור המנהל לאשר מועמדים ושדכנים
    public interface IToAdmin<T>
    {
        List<T> GetUnConfirmationUsers();
        void ConfirmationUser(int id);
        List<T> GetConfirmationUsers();
    }
}
