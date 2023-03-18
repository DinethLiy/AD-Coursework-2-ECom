using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigMemoryService : IManageConfigMemoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigMemoryService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigMemory> GetConfigMemoryList()
        {
            return _context.ConfigMemory
                .Where(mem => mem.DELETED_BY == null)
                .ToList();
        }

        public ConfigMemory? GetTempDataForAddEditConfigMemory(int configMemoryId)
        {
            if (configMemoryId != -1)
            {
                return _context.ConfigMemory
                    .Where(mem => mem.CONFIG_MEMORY_ID == configMemoryId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigMemory(string accessToken, string memoryName, string price, string? memoryDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigMemory newMemory = new()
            {
                MEMORY_NAME = memoryName,
                BASE_PRICE = Decimal.Parse(price),
                MEMORY_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                MEMORY_DESCRIPTION = memoryDesc
            };
            _context.ConfigMemory.Add(newMemory);
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

        public string EditConfigMemory(string accessToken, string memoryId, string memoryName, string price, string status, string? memoryDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundMemory = _context.ConfigMemory
                        .Where(mem => mem.CONFIG_MEMORY_ID == int.Parse(memoryId))
                        .FirstOrDefault();
            foundMemory.MEMORY_NAME = memoryName;
            foundMemory.BASE_PRICE = Decimal.Parse(price);
            foundMemory.MEMORY_STATUS = status;
            foundMemory.MEMORY_DESCRIPTION = memoryDesc;
            foundMemory.MODIFIED_BY = foundUser;
            foundMemory.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return memoryId;
            }
        }

        public string DeleteConfigMemory(string accessToken, string memoryId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundMemory = _context.ConfigMemory
                        .Where(mem => mem.CONFIG_MEMORY_ID == int.Parse(memoryId))
                        .FirstOrDefault();
            foundMemory.MEMORY_STATUS = "INA";
            foundMemory.DELETED_BY = foundUser;
            foundMemory.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return memoryId;
            }
        }
    }
}
