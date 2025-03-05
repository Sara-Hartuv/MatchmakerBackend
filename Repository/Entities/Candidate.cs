using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public enum HeadCovering
    {
        פאה,
        מטפחת,
        פאה_עם_כובע,
        פאה_טופ_לייס,
        גמישה_פאה_או_מטפחת
    }
    public enum Hat
    {
        סאמעט,
        קאפלוטש,
        קנייטש,
        עגול,
        שטריימל
    }
    public enum Suit
    {
        קצרה,
        ארוכה
    }
    public enum Sector//מגזר
    {
        ליטאי,
        חסידי,
        ספרדי,
        תימני,
        חבד,
        חצי_חצי,
        אחר
    }
    public enum SubSector
    {
        ישיבתי,
        בני_תורה_עץ,
        בעלי_תשובה,
        ירושלמי,
        חרדי_מודרני,
        חוצניקים,
        חזונאישניקים,
        זילברמן,
        רקע_חסידי,
        אחר

    }
    public enum CellPhone
    {
        כשר,
        תומך_כשר,
        מכשיר_מוגן,
        סמארטפון,
        פלאפון_SMS,
        פלאפון_מוגן_לצורכי_פרנסה,
        שני_טלאפונים
    }
    public enum Openness
    {
        שמור_ה_מאד,
        שמרן_ית,
        שמור_ה,
        שמור_ה_וראש_פתוח,
        פתוח_ה,
        מודרני_ת,
        מודרני_ת_מאד
    }
    public enum ClothingStyle
    {
        מודרני,
        עדכני,
        מכובד,
        קלאסי,
        פשוט,
        פשוט_מאד
    }
    public enum Physique
    {
        רזה_מאד,
        רזה,
        ממוצעת,
        מלאה

    }
    public enum SkinTone
    {
        בהיר,
        נוטה_לבהיר,
        שזוף,
        נוטה_לכהה,
        כהה
    }
    public enum HairColor
    {
        חום,
        שחור,
        שטני,
        בלונדי,
        גנגי
    }
    public enum FamilyStyle
    {
        מיוחסת,
        חשובה,
        קלאסית,
        עממית
    }
    public enum ParentalStatus
    {
        נשואים,
        גרושים,
        אב_נפטר,
        אם_נפטרה,
        אינם_בחיים
    }
    public enum FamilyOpenness
    {
        מודרנית,
        פתוחה,
        שמרנית,
        פרום,
        ישיבתית,
        בני_תורה,
        חוצניקים
    }
    public enum StudtyType
    {
        ישיבה,
        סמינר
    }
    public class Candidate : User
    {
        public int Id { get; set; } // id אוטומטי

        public Sector Sector { get; set; }//מגזר
        public SubSector SubSector { get; set; }//תת מגזר
        public int GivesMoney { get; set; }
        public int AskingMoney { get; set; }
        public CellPhone CellPhone { get; set; }
        public Openness Openness { get; set; }//פתיחות
        public ClothingStyle ClothingStyle { get; set; }//סגנון לבוש
        public bool License { get; set; }//רשיון
        public double Height { get; set; }//גובה
        public Physique Physique { get; set; }//מבנה גוף
        public SkinTone SkinTone { get; set; }//צבע עור
        public HairColor HairColor { get; set; }//צבע שיער

        public StudtyType LastStudy { get; set; }//מקום לימודים
        public string StudyName { get; set; }
        [ForeignKey("ProfessionId")]
        public int ProfessionId { get; set; }
        public Profession profession { get; set; }//מקצוע
        public string Workplace { get; set; }//מקום עבודה
        public string Description { get; set; }//תאור
        public HeadCovering HeadCovering { get; set; }
        public Hat Hat { get; set; }
        public Suit Suit { get; set; }
        public bool Beard { get; set; }//זקן
        public bool Smoker { get; set; }

        //פרטי משפחה
        public FamilyStyle FamilyStyle { get; set; }//סגנון משפחה
        public ParentalStatus ParentalStatus { get; set; }//מצב ההורים
        public FamilyOpenness FamilyOpenness { get; set; }//רמת פתיחות
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string NameFromHome { get; set; }
        public string MotherOccupation { get; set; }
        //אחים ואחיות
        public List<Brother> Brothers { get; set; }
        public string DescriptionFind { get; set; }
        public List<Inquiries> Inquiries { get; set; }//טלפונים לבירורים
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

    }
}
