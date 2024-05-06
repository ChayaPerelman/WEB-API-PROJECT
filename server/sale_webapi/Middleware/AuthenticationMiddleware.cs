using sale_webapi.Models;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using sale_webapi.BLL;
using server.Models;
using System.Data;

namespace sale_webapi.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;
        public AuthenticationMiddleware() { }
        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var identity = context.User.Identity as ClaimsIdentity;
                if (identity == null)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
                var userClaims = identity.Claims;
                var status = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value;
                var role = EnumRoleUser.custumer;
                if (status == "manager")
                    role = EnumRoleUser.admin;
                int userId;
                int.TryParse(userClaims.FirstOrDefault(o => o.Type == "userId")?.Value ?? "", out userId);

                var user = new User
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    UserLastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    UserPhone = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.HomePhone)?.Value,
                    UserEmail = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    UserFirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    role = role,
                    UserId = userId,                  
            };

                context.Items["User"] = user;
                await _next(context);

            }
               catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the middleware.");
                
            }
        }
    
    }
}
