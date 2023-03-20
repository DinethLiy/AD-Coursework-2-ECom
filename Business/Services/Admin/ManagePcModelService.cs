using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace eComMaster.Business.Services.Admin
{
    public class ManagePcModelService : IManagePcModelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManagePcModelService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<PcModel> GetPcModelList()
        {
            return _context.PcModel
                .Include(pm => pm.PC_SERIES_ID)
                .Where(pm => pm.DELETED_BY == null)
                .ToList();
        }

        // Get data needed for the views
        public ArrayList GetTempDataForAddEditPcModel(int pcModelId)
        {
            ArrayList result = new()
            {
                _context.PcSeries
                    .Where(ps => ps.PC_SERIES_STATUS != "INA")
                    .ToList(),
                _context.ConfigCasing
                    .Where(cas => cas.CASING_STATUS != "INA")
                    .ToList(),
                _context.ConfigDisplay
                    .Where(dis => dis.DISPLAY_STATUS != "INA")
                    .ToList(),
                _context.ConfigGraphics
                    .Where(gra => gra.GRAPHICS_STATUS != "INA")
                    .ToList(),
                _context.ConfigMemory
                    .Where(mem => mem.MEMORY_STATUS != "INA")
                    .ToList(),
                _context.ConfigMisc
                    .Where(mis => mis.MISC_STATUS != "INA")
                    .ToList(),
                _context.ConfigPorts
                    .Where(prt => prt.PORTS_STATUS != "INA")
                    .ToList(),
                _context.ConfigPower
                    .Where(pow => pow.POWER_STATUS != "INA")
                    .ToList(),
                _context.ConfigProcessor
                    .Where(pro => pro.PROCESSOR_STATUS != "INA")
                    .ToList(),
                _context.ConfigStorage
                    .Where(sto => sto.STORAGE_STATUS != "INA")
                    .ToList()
            };
            if (pcModelId != -1)
            {
                result.Add(GetPcModel(pcModelId.ToString()));
            }
            return result;
        }

        public string AddPcModel(string accessToken, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string? modelDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            PcModel newModel = new()
            {
                PC_SERIES_ID = GetPcSeries(series),
                CONFIG_CASING_ID = GetCasing(casing),
                CONFIG_DISPLAY_ID = GetDisplay(display),
                CONFIG_GRAPHICS_ID = GetGraphics(graphics),
                CONFIG_MEMORY_ID = GetMemory(memory),
                CONFIG_MISC_ID = GetMisc(misc),
                CONFIG_PORTS_ID = GetPorts(ports),
                CONFIG_POWER_ID = GetPower(power),
                CONFIG_PROCESSOR_ID = GetProcessor(processor),
                CONFIG_STORAGE_ID = GetStorage(storage),
                PC_MODEL_NAME = modelName,
                PC_MODEL_DESCRIPTION = modelDesc,
                MODEL_PRICE = Decimal.Parse(price),
                QUANTITY = int.Parse(quantity),
                PC_MODEL_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
            };
            _context.PcModel.Add(newModel);
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

        public string EditPcModel(string accessToken, string pcModelId, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string status, string? modelDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundModel = GetPcModel(pcModelId);
            foundModel.PC_SERIES_ID = GetPcSeries(series);
            foundModel.CONFIG_CASING_ID = GetCasing(casing);
            foundModel.CONFIG_DISPLAY_ID = GetDisplay(display);
            foundModel.CONFIG_GRAPHICS_ID = GetGraphics(graphics);
            foundModel.CONFIG_MEMORY_ID = GetMemory(memory);
            foundModel.CONFIG_MISC_ID = GetMisc(misc);
            foundModel.CONFIG_PORTS_ID = GetPorts(ports);
            foundModel.CONFIG_POWER_ID = GetPower(power);
            foundModel.CONFIG_PROCESSOR_ID = GetProcessor(processor);
            foundModel.CONFIG_STORAGE_ID = GetStorage(storage);
            foundModel.PC_MODEL_NAME = modelName;
            foundModel.PC_MODEL_DESCRIPTION = modelDesc;
            foundModel.MODEL_PRICE = Decimal.Parse(price);
            foundModel.QUANTITY = int.Parse(quantity);
            foundModel.PC_MODEL_STATUS = status;
            foundModel.MODIFIED_BY = foundUser;
            foundModel.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return pcModelId;
            }
        }

        public string DeletePcModel(string accessToken, string pcModelId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundModel = GetPcModel(pcModelId);
            foundModel.PC_MODEL_STATUS = "INA";
            foundModel.DELETED_BY = foundUser;
            foundModel.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return pcModelId;
            }
        }

        // Functions that find a record based on the given ID for each type of model
        private PcModel GetPcModel(string pcModelId) 
        {
            return _context.PcModel
                    .Include(pm => pm.PC_SERIES_ID)
                    .Include(pm => pm.CONFIG_CASING_ID)
                    .Include(pm => pm.CONFIG_DISPLAY_ID)
                    .Include(pm => pm.CONFIG_GRAPHICS_ID)
                    .Include(pm => pm.CONFIG_MEMORY_ID)
                    .Include(pm => pm.CONFIG_MISC_ID)
                    .Include(pm => pm.CONFIG_PORTS_ID)
                    .Include(pm => pm.CONFIG_POWER_ID)
                    .Include(pm => pm.CONFIG_PROCESSOR_ID)
                    .Include(pm => pm.CONFIG_STORAGE_ID)
                    .Where(pm => pm.PC_MODEL_ID == int.Parse(pcModelId))
                    .FirstOrDefault();
        }

        private PcSeries GetPcSeries(string pcSeriesId)
        {
            return _context.PcSeries
                        .Where(ps => ps.PC_SERIES_ID == int.Parse(pcSeriesId))
                        .FirstOrDefault();
        }

        private ConfigCasing GetCasing(string casingId)
        {
            return _context.ConfigCasing
                        .Where(cas => cas.CONFIG_CASING_ID == int.Parse(casingId))
                        .FirstOrDefault();
        }

        private ConfigDisplay GetDisplay(string displayId)
        {
            return _context.ConfigDisplay
                        .Where(dis => dis.CONFIG_DISPLAY_ID == int.Parse(displayId))
                        .FirstOrDefault();
        }

        private ConfigGraphics GetGraphics(string graphicsId)
        {
            return _context.ConfigGraphics
                        .Where(gra => gra.CONFIG_GRAPHICS_ID == int.Parse(graphicsId))
                        .FirstOrDefault();
        }

        private ConfigMemory GetMemory(string memoryId)
        {
            return _context.ConfigMemory
                        .Where(mem => mem.CONFIG_MEMORY_ID == int.Parse(memoryId))
                        .FirstOrDefault();
        }

        private ConfigMisc GetMisc(string miscId)
        {
            return _context.ConfigMisc
                        .Where(mis => mis.CONFIG_MISC_ID == int.Parse(miscId))
                        .FirstOrDefault();
        }

        private ConfigPorts GetPorts(string portsId)
        {
            return _context.ConfigPorts
                        .Where(prt => prt.CONFIG_PORTS_ID == int.Parse(portsId))
                        .FirstOrDefault();
        }

        private ConfigPower GetPower(string powerId)
        {
            return _context.ConfigPower
                        .Where(pow => pow.CONFIG_POWER_ID == int.Parse(powerId))
                        .FirstOrDefault();
        }

        private ConfigProcessor GetProcessor(string processorId)
        {
            return _context.ConfigProcessor
                        .Where(pro => pro.CONFIG_PROCESSOR_ID == int.Parse(processorId))
                        .FirstOrDefault();
        }

        private ConfigStorage GetStorage(string storageId)
        {
            return _context.ConfigStorage
                        .Where(sto => sto.CONFIG_STORAGE_ID == int.Parse(storageId))
                        .FirstOrDefault();
        }
    }
}
