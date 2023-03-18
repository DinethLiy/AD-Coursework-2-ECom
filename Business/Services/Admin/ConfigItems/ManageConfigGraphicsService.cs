using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigGraphicsService : IManageConfigGraphicsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigGraphicsService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigGraphics> GetConfigGraphicsList()
        {
            return _context.ConfigGraphics
                .Where(gra => gra.DELETED_BY == null)
                .ToList();
        }

        public ConfigGraphics? GetTempDataForAddEditConfigGraphics(int configGraphicsId)
        {
            if (configGraphicsId != -1)
            {
                return _context.ConfigGraphics
                    .Where(gra => gra.CONFIG_GRAPHICS_ID == configGraphicsId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigGraphics(string accessToken, string graphicsName, string price, string? graphicsDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigGraphics newGraphics = new()
            {
                GRAPHICS_NAME = graphicsName,
                BASE_PRICE = Decimal.Parse(price),
                GRAPHICS_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                GRAPHICS_DESCRIPTION = graphicsDesc
            };
            _context.ConfigGraphics.Add(newGraphics);
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

        public string EditConfigGraphics(string accessToken, string graphicsId, string graphicsName, string price, string status, string? graphicsDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundGraphics = _context.ConfigGraphics
                        .Where(gra => gra.CONFIG_GRAPHICS_ID == int.Parse(graphicsId))
                        .FirstOrDefault();
            foundGraphics.GRAPHICS_NAME = graphicsName;
            foundGraphics.BASE_PRICE = Decimal.Parse(price);
            foundGraphics.GRAPHICS_STATUS = status;
            foundGraphics.GRAPHICS_DESCRIPTION = graphicsDesc;
            foundGraphics.MODIFIED_BY = foundUser;
            foundGraphics.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return graphicsId;
            }
        }

        public string DeleteConfigGraphics(string accessToken, string graphicsId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundGraphics = _context.ConfigGraphics
                        .Where(gra => gra.CONFIG_GRAPHICS_ID == int.Parse(graphicsId))
                        .FirstOrDefault();
            foundGraphics.GRAPHICS_STATUS = "INA";
            foundGraphics.DELETED_BY = foundUser;
            foundGraphics.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return graphicsId;
            }
        }
    }
}
