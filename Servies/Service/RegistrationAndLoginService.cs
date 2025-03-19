using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RegistrationAndLoginService : IRegistrationAndLogin<User>
    {
        private readonly IRepository<Candidate> _repositoryCandidate;
        private readonly IRepository<Matchmaker> _repositoryMatchmaker;
        private readonly IConfiguration config;
        public RegistrationAndLoginService(IRepository<Candidate> repositoryCandidate, IRepository<Matchmaker> repositoryMatchmaker, IConfiguration config)
        {
            _repositoryCandidate = repositoryCandidate;
            _repositoryMatchmaker = repositoryMatchmaker;
            this.config = config;
        }

        public User AddItem(User item, string userType)
        {
            if(userType == "matchmaker")
            {
                Matchmaker m = new Matchmaker();
                m.Email = item.Email;   
                m.Password = item.Password;
                return _repositoryMatchmaker.AddItem(m);
            }
            else if(userType == "candidate")
            {
                Candidate candidate = new Candidate();
                candidate.Email = item.Email;
                candidate.Password = item.Password;
                return _repositoryCandidate.AddItem(candidate);
            }
            throw new InvalidOperationException("Invalid user type");
        }

        public List<User> GetAllCandidates()
        {
            List<Candidate> candidatesList = _repositoryCandidate.GetAll();
            List<User> usersList = new List<User>();
            foreach (Candidate candidate in candidatesList)
            {
                usersList.Add((User)candidate); 
            }
            return usersList; 
        }


        public List<User> GetAllMachmaker()
        {
            List<Matchmaker> matchMakerList = _repositoryMatchmaker.GetAll();
            List<User> usersList = new List<User>();
            foreach (Matchmaker matchmaker in matchMakerList)
            {
                usersList.Add((User)matchmaker);
            }
            return usersList;
        }

        public User Authenticate(string email, string password, string userType)
        {
            if (userType == "matchmaker")
            {
                var user = GetAllMachmaker().FirstOrDefault(x => x.Email == email && x.Password == password);
                return user;
            }
            else if (userType == "candidate")
            {
                var user = GetAllCandidates().FirstOrDefault(x => x.Email == email && x.Password == password);
                return user;
            }
            else
            {
                throw new InvalidOperationException("Invalid user type");
            }
        }


        public string Generate(User user)
        {
            // טוען את מפתח ההצפנה מה- config
            var secretKey = Encoding.UTF8.GetBytes(config["Jwt:Key"]);

            // אם המפתח קצר מדי (פחות מ-32 תווים), נרחיב אותו על ידי הוספת תווים או חזרה על המפתח
            if (secretKey.Length < 32)
            {
                var extendedKey = new byte[32];
                Array.Copy(secretKey, extendedKey, secretKey.Length);
                // אם המפתח קטן מ-32 סיביות, ממלאים את השאר בתווים נוספים
                for (int i = secretKey.Length; i < 32; i++)
                {
                    extendedKey[i] = 0x20; // הוספת תו רווח (או כל תו אחר) עד שהמפתח יהיה בגודל הנדרש
                }
                secretKey = extendedKey;
            }

            // קביעת סוג המשתמש
            string role = "user"; // ברירת מחדל
            if (user.Email == config["Admin:Email"] && user.Password == config["Admin:Password"])
            {
                role = "admin"; // אם המשתמש הוא המנהל, יש לו תפקיד "admin"
            }
            else if (user is Candidate)
            {
                role = "candidate";
            }
            else if (user is Matchmaker)
            {
                role = "matchmaker";
            }

            // יצירת האישורים לחתימה על ה-Token
            var credentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

            // יצירת התביעות (Claims) של המשתמש
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ),
        new Claim(ClaimTypes.Role, role),
        new Claim(ClaimTypes.Email, user.Email.ToString())
    };

            // יצירת ה-Token
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            // החזרת ה-Token כמחרוזת
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public User? Authenticate(string email, string password)
        {
            // חיפוש משתמש לפי אימייל וסיסמה
            User user = _repositoryCandidate.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                user = _repositoryMatchmaker.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
            }

            return user; // במקרה שהמשתמש לא נמצא או שהסיסמה שגויה
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User AddItem(User item)
        {
            throw new NotImplementedException();
        }
    }
    
    }

