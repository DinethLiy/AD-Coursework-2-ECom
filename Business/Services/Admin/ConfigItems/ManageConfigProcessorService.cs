using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigProcessorService : IManageConfigProcessorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigProcessorService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigProcessor> GetConfigProcessorList()
        {
            return _context.ConfigProcessor
                .Where(pro => pro.DELETED_BY == null)
                .ToList();
        }

        public ConfigProcessor? GetTempDataForAddEditConfigProcessor(int configProcessorId)
        {
            if (configProcessorId != -1)
            {
                return _context.ConfigProcessor
                    .Where(pro => pro.CONFIG_PROCESSOR_ID == configProcessorId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigProcessor(string accessToken, string processorName, string price, string? processorDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigProcessor newProcessor = new()
            {
                PROCESSOR_NAME = processorName,
                BASE_PRICE = Decimal.Parse(price),
                PROCESSOR_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                PROCESSOR_DESCRIPTION = processorDesc
            };
            _context.ConfigProcessor.Add(newProcessor);
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

        public string EditConfigProcessor(string accessToken, string processorId, string processorName, string price, string status, string? processorDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundProcessor = _context.ConfigProcessor
                        .Where(pro => pro.CONFIG_PROCESSOR_ID == int.Parse(processorId))
                        .FirstOrDefault();
            foundProcessor.PROCESSOR_NAME = processorName;
            foundProcessor.BASE_PRICE = Decimal.Parse(price);
            foundProcessor.PROCESSOR_STATUS = status;
            foundProcessor.PROCESSOR_DESCRIPTION = processorDesc;
            foundProcessor.MODIFIED_BY = foundUser;
            foundProcessor.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return processorId;
            }
        }

        public string DeleteConfigProcessor(string accessToken, string processorId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundProcessor = _context.ConfigProcessor
                        .Where(pro => pro.CONFIG_PROCESSOR_ID == int.Parse(processorId))
                        .FirstOrDefault();
            foundProcessor.PROCESSOR_STATUS = "INA";
            foundProcessor.DELETED_BY = foundUser;
            foundProcessor.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return processorId;
            }
        }
    }
}
