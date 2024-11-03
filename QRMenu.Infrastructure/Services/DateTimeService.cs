// QRMenu.Infrastructure/Services/DateTimeService.cs
using QRMenu.Infrastructure.Common.Interfaces;

namespace QRMenu.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}