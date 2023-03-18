using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigPortsService : IManageConfigPortsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigPortsService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigPorts> GetConfigPortsList()
        {
            return _context.ConfigPorts
                .Where(prt => prt.DELETED_BY == null)
                .ToList();
        }

        public ConfigPorts? GetTempDataForAddEditConfigPorts(int configPortsId)
        {
            if (configPortsId != -1)
            {
                return _context.ConfigPorts
                    .Where(prt => prt.CONFIG_PORTS_ID == configPortsId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigPorts(string accessToken, string portsName, string price, string? portsDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigPorts newPorts = new()
            {
                PORTS_NAME = portsName,
                BASE_PRICE = Decimal.Parse(price),
                PORTS_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                PORTS_DESCRIPTION = portsDesc
            };
            _context.ConfigPorts.Add(newPorts);
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

        public string EditConfigPorts(string accessToken, string portsId, string portsName, string price, string status, string? portsDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundPorts = _context.ConfigPorts
                        .Where(prt => prt.CONFIG_PORTS_ID == int.Parse(portsId))
                        .FirstOrDefault();
            foundPorts.PORTS_NAME = portsName;
            foundPorts.BASE_PRICE = Decimal.Parse(price);
            foundPorts.PORTS_STATUS = status;
            foundPorts.PORTS_DESCRIPTION = portsDesc;
            foundPorts.MODIFIED_BY = foundUser;
            foundPorts.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return portsId;
            }
        }

        public string DeleteConfigPorts(string accessToken, string portsId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundPorts = _context.ConfigPorts
                        .Where(prt => prt.CONFIG_PORTS_ID == int.Parse(portsId))
                        .FirstOrDefault();
            foundPorts.PORTS_STATUS = "INA";
            foundPorts.DELETED_BY = foundUser;
            foundPorts.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return portsId;
            }
        }
    }
}
