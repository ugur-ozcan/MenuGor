// QRMenu.Infrastructure/Services/CurrentUserService.cs
using Microsoft.AspNetCore.Http;
using QRMenu.Infrastructure.Common.Interfaces;
using System.Security.Claims;

namespace QRMenu.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId
    {
        get
        {
            return _httpContextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}