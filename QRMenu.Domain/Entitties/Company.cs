// QRMenu.Domain/Entities/Company.cs
using QRMenu.Domain.Common;

namespace QRMenu.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }  // URL'de kullanılacak benzersiz kod
    public string Logo { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string DatabaseType { get; set; }  // MSSQL, MySQL vs.
    public string ConnectionString { get; set; }  // Şifrelenmiş connection string
    public string MenuQuery { get; set; }  // View veya SQL sorgusu
    public string DesignTemplate { get; set; }  // Seçilen menü tasarımı
    public string ThemeColors { get; set; }  // JSON formatında renk şeması
    public DateTime LicenseEndDate { get; set; }
    public bool ShowTableNumber { get; set; }
    public string TableQuery { get; set; }  // Masa doluluk bilgisi için sorgu

    // Navigation properties
    public virtual ICollection<Branch> Branches { get; set; }
    public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; }

    public Company()
    {
        Branches = new HashSet<Branch>();
        SocialMediaLinks = new HashSet<SocialMediaLink>();
    }
}