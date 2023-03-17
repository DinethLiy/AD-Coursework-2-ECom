using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigCasingService : IManageConfigCasingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigCasingService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigCasing> GetConfigCasingList()
        {
            return _context.ConfigCasing
                .Where(cas => cas.DELETED_BY == null)
                .ToList();
        }

        public ConfigCasing? GetTempDataForAddEditConfigCasing(int configCasingId)
        {
            if (configCasingId != -1)
            {
                return _context.ConfigCasing
                    .Where(cas => cas.CONFIG_CASING_ID == configCasingId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigCasing(string accessToken, string casingName, string price, string? casingDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigCasing newCasing = new()
            {
                CASING_NAME = casingName,
                BASE_PRICE = Decimal.Parse(price),
                CASING_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                CASING_DESCRIPTION = casingDesc
            };
            _context.ConfigCasing.Add(newCasing);
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

        public string EditConfigCasing(string accessToken, string casingId, string casingName, string price, string status, string? casingDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundCasing = _context.ConfigCasing
                        .Where(cas => cas.CONFIG_CASING_ID == int.Parse(casingId))
                        .FirstOrDefault();
            foundCasing.CASING_NAME = casingName;
            foundCasing.BASE_PRICE = Decimal.Parse(price);
            foundCasing.CASING_STATUS = status;
            foundCasing.CASING_DESCRIPTION = casingDesc;
            foundCasing.MODIFIED_BY = foundUser;
            foundCasing.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return casingId;
            }
        }

        public string DeleteConfigCasing(string accessToken, string casingId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundCasing = _context.ConfigCasing
                        .Where(cas => cas.CONFIG_CASING_ID == int.Parse(casingId))
                        .FirstOrDefault();
            foundCasing.CASING_STATUS = "INA";
            foundCasing.DELETED_BY = foundUser;
            foundCasing.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return casingId;
            }
        }
    }
}
