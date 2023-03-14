using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eComMaster.Business.Services.Auth
{
    public class AuthService : IAuthService
    {
		private readonly ApplicationDbContext _context;
		private readonly IJwtSecurityService _jwtAuth;
		private string token;
		private CookieOptions cookieOptions;
		private string privilegeType;

		public AuthService(ApplicationDbContext context, IJwtSecurityService jwtAuth)
		{
			_context = context;
			_jwtAuth = jwtAuth;
		}

		public string LoginUser(string username, string password)
		{
			EncryptDecryptText encryptDecryptText = new();
			string encryptedPassword = "";
			if (password != null)
			{
				encryptedPassword = encryptDecryptText.EncryptText(password);
			}
			AuthUser? foundAccount = _context.AuthUser
				.Where(u => u.USERNAME == username && u.PASSWORD == encryptedPassword && u.USER_STATUS == "ACT")
				.FirstOrDefault();

			if (foundAccount != null)
			{
				privilegeType = LoggedInUserAuthentication(foundAccount);
                return RedirectToDashboard(privilegeType);
			}
			else
			{
				return "error";
			}
		}

		public string GetToken()
		{
			return token;
		}

		public CookieOptions GetCookieOptions()
		{
			return cookieOptions;
		}

		public string GetPrivilegeType() 
		{
			return privilegeType;
		}

		public AuthUser? GetLoggedInUser(string accessToken) 
		{
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(accessToken);
            string? userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value.ToString();
            return _context.AuthUser
                .Where(au => au.USER_ID == int.Parse(userId))
                .FirstOrDefault();
        }

		private string LoggedInUserAuthentication(AuthUser foundAccount)
		{
			token = _jwtAuth.JwtAuthentication(foundAccount);
			var tokenHandler = new JwtSecurityTokenHandler();
			var jwtToken = tokenHandler.ReadJwtToken(token);
			string? role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value.ToString();
			cookieOptions = new CookieOptions
			{
				HttpOnly = true,
				Secure = true, // only transmit over HTTPS
				SameSite = SameSiteMode.Strict, // prevent CSRF attacks
				Expires = DateTime.UtcNow.AddHours(1)
			};
			role ??= "empty";
			return role;
		}

		private string RedirectToDashboard(string? role)
		{
			if (role == "SUPER_ADMIN")
			{
				return "SuperAdminHome";
			}
			else if (role == "ADMIN")
			{
				return "AdminHome";
			}
			else
			{
				return "Home";
			}
		}
	}
}
