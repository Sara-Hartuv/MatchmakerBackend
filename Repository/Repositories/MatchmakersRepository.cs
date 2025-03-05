using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MatchmakersRepository : IRepository<Matchmaker>
    {
        private readonly IContext context;
        public MatchmakersRepository(IContext context)
        {
            this.context = context;
        }
        public Matchmaker AddItem(Matchmaker item)
        {
            context.Matchmakers.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Matchmakers.Remove(Get(id));
            context.Save();
        }

        public Matchmaker Get(int id)
        {
            return context.Matchmakers.FirstOrDefault(x => x.Id == id);
        }

        public List<Matchmaker> GetAll()
        {
            return context.Matchmakers.ToList();
        }

        public Matchmaker UpdateItem(int id, Matchmaker item)
        {
            Matchmaker m=Get(id);
            m.NumId=item.NumId;
            m.Adress=item.Adress;
            m.BornDate=item.BornDate;
            m.City=item.City;
            m.Email=item.Email;
            m.ExperienceYear=item.ExperienceYear;
            m.Gender=item.Gender;
            m.FirstName=item.FirstName;
            m.LastName=item.LastName;
            m.Password=item.Password;
            m.Phone=item.Phone;
            context.Save();
            return m;
        }
    }
}
