using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigPowerService : IManageConfigPowerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigPowerService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigPower> GetConfigPowerList()
        {
            return _context.ConfigPower
                .Where(pow => pow.DELETED_BY == null)
                .ToList();
        }

        public ConfigPower? GetTempDataForAddEditConfigPower(int configPowerId)
        {
            if (configPowerId != -1)
            {
                return _context.ConfigPower
                    .Where(pow => pow.CONFIG_POWER_ID == configPowerId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigPower(string accessToken, string powerName, string price, string? powerDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigPower newPower = new()
            {
                POWER_NAME = powerName,
                BASE_PRICE = Decimal.Parse(price),
                POWER_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                POWER_DESCRIPTION = powerDesc
            };
            _context.ConfigPower.Add(newPower);
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

        public string EditConfigPower(string accessToken, string powerId, string powerName, string price, string status, string? powerDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundPower = _context.ConfigPower
                        .Where(pow => pow.CONFIG_POWER_ID == int.Parse(powerId))
                        .FirstOrDefault();
            foundPower.POWER_NAME = powerName;
            foundPower.BASE_PRICE = Decimal.Parse(price);
            foundPower.POWER_STATUS = status;
            foundPower.POWER_DESCRIPTION = powerDesc;
            foundPower.MODIFIED_BY = foundUser;
            foundPower.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return powerId;
            }
        }

        public string DeleteConfigPower(string accessToken, string powerId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundPower = _context.ConfigPower
                        .Where(pow => pow.CONFIG_POWER_ID == int.Parse(powerId))
                        .FirstOrDefault();
            foundPower.POWER_STATUS = "INA";
            foundPower.DELETED_BY = foundUser;
            foundPower.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return powerId;
            }
        }
    }
}
