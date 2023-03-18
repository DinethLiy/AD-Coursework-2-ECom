using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Services.Admin.ConfigItems
{
    public class ManageConfigStorageService : IManageConfigStorageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageConfigStorageService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<ConfigStorage> GetConfigStorageList()
        {
            return _context.ConfigStorage
                .Where(sto => sto.DELETED_BY == null)
                .ToList();
        }

        public ConfigStorage? GetTempDataForAddEditConfigStorage(int configStorageId)
        {
            if (configStorageId != -1)
            {
                return _context.ConfigStorage
                    .Where(sto => sto.CONFIG_STORAGE_ID == configStorageId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddConfigStorage(string accessToken, string storageName, string price, string? storageDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            ConfigStorage newStorage = new()
            {
                STORAGE_NAME = storageName,
                BASE_PRICE = Decimal.Parse(price),
                STORAGE_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
                STORAGE_DESCRIPTION = storageDesc
            };
            _context.ConfigStorage.Add(newStorage);
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

        public string EditConfigStorage(string accessToken, string storageId, string storageName, string price, string status, string? storageDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundStorage = _context.ConfigStorage
                        .Where(sto => sto.CONFIG_STORAGE_ID == int.Parse(storageId))
                        .FirstOrDefault();
            foundStorage.STORAGE_NAME = storageName;
            foundStorage.BASE_PRICE = Decimal.Parse(price);
            foundStorage.STORAGE_STATUS = status;
            foundStorage.STORAGE_DESCRIPTION = storageDesc;
            foundStorage.MODIFIED_BY = foundUser;
            foundStorage.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return storageId;
            }
        }

        public string DeleteConfigStorage(string accessToken, string storageId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundStorage = _context.ConfigStorage
                        .Where(sto => sto.CONFIG_STORAGE_ID == int.Parse(storageId))
                        .FirstOrDefault();
            foundStorage.STORAGE_STATUS = "INA";
            foundStorage.DELETED_BY = foundUser;
            foundStorage.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return storageId;
            }
        }
    }
}
