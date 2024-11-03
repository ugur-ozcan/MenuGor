// QRMenu.Domain/Entities/Branch.cs
using QRMenu.Domain.Common;

namespace QRMenu.Domain.Entities;

public class Branch : BaseEntity
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }  // URL'de kullanılacak benzersiz kod
    public string Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Phone { get; set; }

    // Navigation property
    public virtual Company Company { get; set; }
}