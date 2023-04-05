using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace eComMaster.Data.Utility
{
    public class Authorization : ActionFilterAttribute
    {
        public string RequiredPrivilegeType { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = filterContext.HttpContext.Request.Cookies["access_token"];

            if (string.IsNullOrEmpty(token))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                { "Controller", "Auth" },
                { "Action", "AccessDenied" }
                    });
                return;
            }

            try
            {
                var tokenValidationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("gVkYp3s6v9y$B?E(H+MbQeThWmZq4t7w")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var principal = jwtHandler.ValidateToken(token, tokenValidationParams, out var validatedToken);

                var privilegeTypeClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (privilegeTypeClaim != RequiredPrivilegeType)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                    { "Controller", "Auth" },
                    { "Action", "AccessDenied" }
                        });
                }
            }
            catch (SecurityTokenException)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                { "Controller", "Auth" },
                { "Action", "AccessDenied" }
                    });
            }
        }
    }
}
