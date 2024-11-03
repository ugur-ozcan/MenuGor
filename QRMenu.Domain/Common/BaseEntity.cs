﻿//Base Entity Class

// QRMenu.Domain/Common/BaseEntity.cs
namespace QRMenu.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string DeletedBy { get; set; }
}