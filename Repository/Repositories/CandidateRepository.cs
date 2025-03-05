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
    public class CandidateRepository : IRepository<Candidate>
    {
        private readonly IContext context;
        public CandidateRepository(IContext context)
        {
            this.context = context;
        }
        public Candidate AddItem(Candidate item)
        {
            context.Candidates.Add(item);
            context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Candidates.Remove(Get(id));
            context.Save();
        }

        public Candidate Get(int id)
        {
            return context.Candidates.FirstOrDefault(x => x.Id == id);
        }

        public List<Candidate> GetAll()
        {
            return context.Candidates.ToList();
        }

        public Candidate UpdateItem(int id, Candidate item)
        {
            Candidate c = Get(id);
            c.HairColor = item.HairColor;
            c.Adress = item.Adress;
            c.AskingMoney=item.AskingMoney;
            c.Status = item.Status;
            c.Suit= item.Suit;
            c.profession = item.profession;
            c.Phone = item.Phone;
            c.ParentalStatus = item.ParentalStatus;
            c.Password = item.Password;
            c.LastStudy = item.LastStudy;
            c.LastName = item.LastName; 
            c.FirstName = item.FirstName;
            c.Description = item.Description;
            c.SubSector = item.SubSector;
            c.SkinTone = item.SkinTone;
            c.Physique = item.Physique;
            c.Gender=item.Gender;   
            c.FamilyStyle=item.FamilyStyle;
            c.Email=item.Email;
            c.AskingMoney = item.AskingMoney;
            c.Beard=item.Beard;
            c.BornDate=item.BornDate;
            c.DescriptionFind=item.DescriptionFind;
            c.CellPhone=item.CellPhone;
            c.Brothers=item.Brothers;
            c.City=item.City;
            c.ClothingStyle
                = item.ClothingStyle;
            c.FatherName=item.FatherName;
            c.FamilyOpenness=item.FamilyOpenness;
            c.GivesMoney
                = item.GivesMoney;
            c.Hat=item.Hat;
            c.HeadCovering=item.HeadCovering;
            c.Height=item.Height;
            c.ImageUrl=item.ImageUrl;   
            c.Inquiries=item.Inquiries;
            c.FatherOccupation=item.FatherOccupation;
            c.FirstName=item.FirstName; 
            c.License=item.License;
            c.MotherName=item.MotherName;
            c.MotherOccupation=item.MotherOccupation;
            c.NameFromHome=item.NameFromHome;
            c.NumId=item.NumId;
            c.Workplace=item.Workplace;
            c.Openness=item.Openness;
            c.ParentalStatus=item.ParentalStatus;
            context.Save();
            return c;
        }
    }
}
