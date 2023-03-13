using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.SuperAdmin;
using eComMaster.Data;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace eComMaster.Business.Services.SuperAdmin
{
    public class ManageAdminsService : IManageAdminsService
    {
        private readonly ApplicationDbContext _context;

        public ManageAdminsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AuthUser> GetAdminList()
        {
            return _context.AuthUser
                .Where(au => au.PRIVILEGE_TYPE == "ADMIN" || au.PRIVILEGE_TYPE == "SUPER_ADMIN")
                .ToList();
        }

        public ArrayList? GetTempDataForAddEditAdmins(int userId, string? encryptedPassword) 
        {
            ArrayList result = new();
            if (encryptedPassword != "-1")
            {
                EncryptDecryptText encryptDecryptText = new();
                result.Add(_context.AuthUser
                    .Where(u => u.USER_ID == userId)
                    .FirstOrDefault());
                if(encryptedPassword != null) 
                { 
                    result.Add(encryptDecryptText.DecryptText(encryptedPassword));
                }
                return result;
            }
            else 
            {
                return null;
            }
        }

        public string AddAdmin(string username, string password, string confirmPassword, string type) 
        {
            EncryptDecryptText encryptDecryptText = new();
            if (password == confirmPassword)
            {
                AuthUser newAdmin = new()
                {
                    USERNAME = username,
                    PASSWORD = encryptDecryptText.EncryptText(password),
                    PRIVILEGE_TYPE = type,
                };
                _context.AuthUser.Add(newAdmin);
                try
                {
                    _context.SaveChanges();
                    return "success";
                }
                catch
                {
                    return "error";
                }
            }
            else 
            {
                return "error";
            }
        }

        public string EditAdmin(string userId, string username, string password, string confirmPassword, string type, string status) 
        {
            EncryptDecryptText encryptDecryptText = new();
            var foundAdmin = _context.AuthUser
                        .Where(u => u.USER_ID == int.Parse(userId))
                        .FirstOrDefault();
            if (confirmPassword == password)
            {

                foundAdmin.USERNAME = username;
                foundAdmin.PASSWORD = encryptDecryptText.EncryptText(password);
                foundAdmin.PRIVILEGE_TYPE = type;
                foundAdmin.USER_STATUS = status;
                try
                {
                    _context.SaveChanges();
                    return "success";
                }
                catch
                {
                    return encryptDecryptText.DecryptText(foundAdmin.PASSWORD);
                }
            }
            else
            {
                return encryptDecryptText.DecryptText(foundAdmin.PASSWORD);
            }
        }
    }
}
