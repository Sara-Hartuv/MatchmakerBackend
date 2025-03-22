using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            c.Sector = item.Sector;
            c.SubSector = item.SubSector;
            c.GivesMoney = item.GivesMoney;
            c.AskingMoney = item.AskingMoney;
            c.CellPhone = item.CellPhone;
            c.Openness = item.Openness;
            c.ClothingStyle = item.ClothingStyle;
            c.License = item.License;
            c.Height = item.Height;
            c.Physique = item.Physique;
            c.SkinTone = item.SkinTone;
            c.HairColor = item.HairColor;
            c.LastStudy = item.LastStudy;
            c.StudyName = item.StudyName;
            c.profession = item.profession;
            c.Workplace = item.Workplace;
            c.Description = item.Description;
            c.HeadCovering = item.HeadCovering;
            c.Hat = item.Hat;
            c.Suit = item.Suit;
            c.Beard = item.Beard;
            c.Smoker = item.Smoker;
            c.FamilyStyle = item.FamilyStyle;
            c.ParentalStatus = item.ParentalStatus;
            c.FamilyOpenness = item.FamilyOpenness;
            c.FatherName = item.FatherName;
            c.FatherOccupation = item.FatherOccupation;
            c.MotherName = item.MotherName;
            c.NameFromHome = item.NameFromHome;
            c.MotherOccupation = item.MotherOccupation;
            c.Brothers = null;
            c.Brothers = new List<Brother>();
            c.Brothers.AddRange(item.Brothers);
            c.DescriptionFind = item.DescriptionFind;
            c.Inquiries = null;
            c.Inquiries = new List<Inquiries>();
            c.Inquiries.AddRange(item.Inquiries);
            c.ImageUrl = item.ImageUrl;
            c.FirstName = item.FirstName;
            c.LastName = item.LastName;
            c.Gender = item.Gender;
            c.NumId = item.NumId;
            c.BornDate = item.BornDate;
            c.Phone = item.Phone;
            c.Email = item.Email;
            c.Password = item.Password;
            c.City = item.City;
            c.Adress = item.Adress;
            context.Save();
            return c;
        }
    }
}
