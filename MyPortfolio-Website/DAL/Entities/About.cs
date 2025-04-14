using Microsoft.EntityFrameworkCore;

namespace MyPortfolio_Website.DAL.Entities
{
    [PrimaryKey(nameof(AboutId))]
    public class About
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
        public string NameDesc { get; set; }
        public string Degree { get; set; }
        public string DegreeDesc { get; set; }
        public string Phone { get; set; }
        public string PhoneDesc { get; set; }
        public string Adress { get; set; }
        public string AdressDesc { get; set; }
        public string Birthday { get; set; }
        public string Birthdaydesc { get; set; }
        public string Experience { get; set; }
        public string ExperienceDesc { get; set; }
        public string Email { get; set; }
        public string EmailDesc { get; set; }
        public string Freelance { get; set; }
        public string FreelanceDesc { get; set; }
        public string SubArea1 { get; set; }
        public string SubArea2 { get; set; }
        public string SubArea3 { get; set; }
        public string SubArea4 { get; set; }
        public string SubArea5 { get; set; }
        public string SubArea6 { get; set; }
    }
}
