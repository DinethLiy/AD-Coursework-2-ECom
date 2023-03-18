using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigDisplayService : IManageConfigDisplayService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigDisplayService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigDisplay> GetConfigDisplayList()
        {
            return _context.ConfigDisplay
                .Where(dis => dis.DELETED_BY == null)
                .ToList();
        }

        public ConfigDisplay? GetTempDataForAddEditConfigDisplay(int configDisplayId)
        {
            if (configDisplayId != -1)
            {
                return _context.ConfigDisplay
                    .Where(dis => dis.CONFIG_DISPLAY_ID == configDisplayId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigDisplay(string accessToken, string displayName, string price, string? displayDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigDisplay newDisplay = new()
            {
                DISPLAY_NAME = displayName,
                BASE_PRICE = Decimal.Parse(price),
                DISPLAY_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                DISPLAY_DESCRIPTION = displayDesc
            };
            _context.ConfigDisplay.Add(newDisplay);
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

        public string EditConfigDisplay(string accessToken, string displayId, string displayName, string price, string status, string? displayDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundDisplay = _context.ConfigDisplay
                        .Where(dis => dis.CONFIG_DISPLAY_ID == int.Parse(displayId))
                        .FirstOrDefault();
            foundDisplay.DISPLAY_NAME = displayName;
            foundDisplay.BASE_PRICE = Decimal.Parse(price);
            foundDisplay.DISPLAY_STATUS = status;
            foundDisplay.DISPLAY_DESCRIPTION = displayDesc;
            foundDisplay.MODIFIED_BY = foundUser;
            foundDisplay.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return displayId;
            }
        }

        public string DeleteConfigDisplay(string accessToken, string displayId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundDisplay = _context.ConfigDisplay
                        .Where(dis => dis.CONFIG_DISPLAY_ID == int.Parse(displayId))
                        .FirstOrDefault();
            foundDisplay.DISPLAY_STATUS = "INA";
            foundDisplay.DELETED_BY = foundUser;
            foundDisplay.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return displayId;
            }
        }
    }
}
