using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio_Website.DAL.Entities
{
    public class User
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        // Hashlenmiş şifre
        public string PasswordHash { get; set; }

        // Salt (şifreleme için rastgele oluşturulan veri)
        public string Salt { get; set; }

        // Bu özellik veritabanında saklanmaz, sadece API istemcisinden alınan şifreyi temsil eder.
        [NotMapped]
        public string Password { get; set; }  // Sadece geçici bir alan, veritabanına kaydedilmez


        public string Email { get; set; }
        public string? ResetToken { get; set; }  // Şifre sıfırlama token'ı
        public DateTime? TokenExpiry { get; set; }
    }
}
