using System;
using System.Collections;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.EntityFrameworkCore;


namespace eComMaster.Business.Services.Home
{
    public class ManageModelService : IManageModelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        public ManageModelService(ApplicationDbContext applicationDbContext, IAuthService authService)
        {
            _context = applicationDbContext;
            _authService = authService;
        }
        public List<PcModel> GetPcModels(int pcSeriesId, string accessToken) {
            
            var modelList = _context.PcModel
            .Where(x => x.DELETED_BY == null && x.PC_MODEL_STATUS != "INA" &&
            x.CREATED_BY.PRIVILEGE_TYPE == "ADMIN" || x.CREATED_BY == _authService.GetLoggedInUser(accessToken))
            .Include(x => x.PC_SERIES_ID)
  
            .ToList();
             
            return modelList;

        }
        public PcModel getPcModelForId(int id) {
            var model = _context.PcModel.Find(id);
            if (model == null) {
                return null;

            }
            return model;
        }
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
                result.Add(getPcModelForId(pcModelId));
            }
            return result;
        }
        public string AddCustomPcModel(string accessToken, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string? modelDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            double parsedPrice = Double.Parse(price);
            var PC_SERIES_ID = GetPcSeries(series);
            var CONFIG_CASING_ID = GetCasing(casing);
            var CONFIG_DISPLAY_ID = GetDisplay(display);
            var CONFIG_GRAPHICS_ID = GetGraphics(graphics);
            var CONFIG_MEMORY_ID = GetMemory(memory);
            var CONFIG_MISC_ID = GetMisc(misc);
            var CONFIG_PORTS_ID = GetPorts(ports);
            var CONFIG_POWER_ID = GetPower(power);
            var CONFIG_PROCESSOR_ID = GetProcessor(processor);
            var CONFIG_STORAGE_ID = GetStorage(storage);
            var finalPrice = parsedPrice + Double.Parse(CONFIG_CASING_ID.BASE_PRICE.ToString())
            + Double.Parse(CONFIG_DISPLAY_ID.BASE_PRICE.ToString())
            +Double.Parse(CONFIG_GRAPHICS_ID.BASE_PRICE.ToString())
            +Double.Parse(CONFIG_MEMORY_ID.BASE_PRICE.ToString())
            + Double.Parse(CONFIG_MISC_ID.BASE_PRICE.ToString())
            + Double.Parse(CONFIG_PORTS_ID.BASE_PRICE.ToString())
            + Double.Parse(CONFIG_POWER_ID.BASE_PRICE.ToString())
            + Double.Parse(CONFIG_PROCESSOR_ID.BASE_PRICE.ToString())
            + Double.Parse(CONFIG_STORAGE_ID.BASE_PRICE.ToString());
            PcModel newModel = new()
            {
                PC_SERIES_ID = PC_SERIES_ID,
                CONFIG_CASING_ID = CONFIG_CASING_ID,
                CONFIG_DISPLAY_ID = CONFIG_DISPLAY_ID,
                CONFIG_GRAPHICS_ID = CONFIG_GRAPHICS_ID,
                CONFIG_MEMORY_ID = CONFIG_MEMORY_ID,
                CONFIG_MISC_ID = CONFIG_MISC_ID,
                CONFIG_PORTS_ID = CONFIG_PORTS_ID,
                CONFIG_POWER_ID = CONFIG_POWER_ID,
                CONFIG_PROCESSOR_ID = CONFIG_PROCESSOR_ID,
                CONFIG_STORAGE_ID = CONFIG_STORAGE_ID,
                PC_MODEL_NAME = modelName,
                PC_MODEL_DESCRIPTION = modelDesc,
                MODEL_PRICE = Decimal.Parse(finalPrice.ToString()),
                QUANTITY = 1,
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

