using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MatchRepository : IRepository<Match>
    {
        private readonly IContext context;
        public MatchRepository(IContext context)
        {
            this.context = context;
        }
        public Match AddItem(Match item)
        {
            context.Matches.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Matches.Remove(Get(id));
            context.Save();
        }

        public Match Get(int id)
        {
            return context.Matches.FirstOrDefault(x => x.Id == id);
        }

        public List<Match> GetAll()
        {
            return context.Matches.ToList();
        }

        public Match UpdateItem(int id, Match item)
        {
            Match match=Get(id);
            match.DateMatch= DateTime.Now;
            match.Status = item.Status;
            match.IsEngaged=item.IsEngaged;
            match.ConfirmationGuy = item.ConfirmationGuy;
            match.ConfirmationGirl = item.ConfirmationGirl;
            context.Save();
            return match;


        }
        

    }
}
