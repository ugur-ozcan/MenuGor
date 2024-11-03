// QRMenu.Domain/Entities/SocialMediaLink.cs
using QRMenu.Domain.Common;

namespace QRMenu.Domain.Entities;

public class SocialMediaLink : BaseEntity
{
    public Guid CompanyId { get; set; }
    public string Platform { get; set; }  // Instagram, Facebook, Twitter vs.
    public string Url { get; set; }

    // Navigation property
    public virtual Company Company { get; set; }
}