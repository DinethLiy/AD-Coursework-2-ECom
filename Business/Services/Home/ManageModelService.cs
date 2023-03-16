using System;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using Microsoft.EntityFrameworkCore;


namespace eComMaster.Business.Services.Home
{
    public class ManageModelService : IManageModelService
    {
        private readonly ApplicationDbContext _context;
        public ManageModelService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public List<PcModel> GetPcModels(int pcSeriesId) {

            var modelList = _context.PcModel
            .Where(x => x.DELETED_BY == null && x.PC_MODEL_STATUS != "INA" && x.CREATED_BY.PRIVILEGE_TYPE == "ADMIN")
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
    }
}

