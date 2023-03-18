using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigMiscService : IManageConfigMiscService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigMiscService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigMisc> GetConfigMiscList()
        {
            return _context.ConfigMisc
                .Where(mis => mis.DELETED_BY == null)
                .ToList();
        }

        public ConfigMisc? GetTempDataForAddEditConfigMisc(int configMiscId)
        {
            if (configMiscId != -1)
            {
                return _context.ConfigMisc
                    .Where(mis => mis.CONFIG_MISC_ID == configMiscId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigMisc(string accessToken, string miscName, string price, string? miscDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigMisc newMisc = new()
            {
                MISC_NAME = miscName,
                BASE_PRICE = Decimal.Parse(price),
                MISC_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                MISC_DESCRIPTION = miscDesc
            };
            _context.ConfigMisc.Add(newMisc);
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

        public string EditConfigMisc(string accessToken, string miscId, string miscName, string price, string status, string? miscDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundMisc = _context.ConfigMisc
                        .Where(mis => mis.CONFIG_MISC_ID == int.Parse(miscId))
                        .FirstOrDefault();
            foundMisc.MISC_NAME = miscName;
            foundMisc.BASE_PRICE = Decimal.Parse(price);
            foundMisc.MISC_STATUS = status;
            foundMisc.MISC_DESCRIPTION = miscDesc;
            foundMisc.MODIFIED_BY = foundUser;
            foundMisc.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return miscId;
            }
        }

        public string DeleteConfigMisc(string accessToken, string miscId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundMisc = _context.ConfigMisc
                        .Where(mis => mis.CONFIG_MISC_ID == int.Parse(miscId))
                        .FirstOrDefault();
            foundMisc.MISC_STATUS = "INA";
            foundMisc.DELETED_BY = foundUser;
            foundMisc.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return miscId;
            }
        }
    }
}
