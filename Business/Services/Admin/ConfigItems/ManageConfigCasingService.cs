using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigCasingService
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
            };
            newCasing.CASING_DESCRIPTION = casingDesc;
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
    }
}
