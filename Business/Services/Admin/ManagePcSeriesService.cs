using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace eComMaster.Business.Services.Admin
{
    public class ManagePcSeriesService : IManagePcSeriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManagePcSeriesService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<PcSeries> GetPcSeriesList()
        {
            return _context.PcSeries
                .Include(ps => ps.PC_CATEGORY_ID)
                .Where(ps => ps.DELETED_BY == null)
                .ToList();
        }

        // Get data needed for the views
        public ArrayList GetTempDataForAddEditPcSeries(int pcSeriesId)
        {
            ArrayList result = new()
            {
                _context.PcCategory
                    .Where(pc => pc.PC_CATEGORY_STATUS != "INA")
                    .ToList()
            };
            if (pcSeriesId != -1)
            {
                result.Add(_context.PcSeries
                    .Include(ps => ps.PC_CATEGORY_ID)
                    .Where(ps => ps.PC_SERIES_ID == pcSeriesId)
                    .FirstOrDefault());
            }
            return result;
        }

        public string AddPcSeries(string accessToken, string seriesName, string category, string? seriesDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            PcSeries newSeries = new()
            {
                PC_CATEGORY_ID = GetPcCategory(category),
                PC_SERIES_NAME = seriesName,
                PC_SERIES_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
            };
            newSeries.PC_SERIES_DESCRIPTION = seriesDesc;
            _context.PcSeries.Add(newSeries);
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

        public string EditPcSeries(string accessToken, string pcSeriesId, string seriesName, string status, string category, string? seriesDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundSeries = _context.PcSeries
                        .Include(ps => ps.PC_CATEGORY_ID)
                        .Where(ps => ps.PC_SERIES_ID == int.Parse(pcSeriesId))
                        .FirstOrDefault();
            foundSeries.PC_CATEGORY_ID = GetPcCategory(category);
            foundSeries.PC_SERIES_NAME = seriesName;
            foundSeries.PC_SERIES_STATUS = status;
            foundSeries.PC_SERIES_DESCRIPTION = seriesDesc;
            foundSeries.MODIFIED_BY = foundUser;
            foundSeries.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return pcSeriesId;
            }
        }

        public string DeletePcSeries(string accessToken, string pcSeriesId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundSeries = _context.PcSeries
                        .Where(ps => ps.PC_SERIES_ID == int.Parse(pcSeriesId))
                        .FirstOrDefault();
            foundSeries.PC_SERIES_STATUS = "INA";
            foundSeries.DELETED_BY = foundUser;
            foundSeries.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return pcSeriesId;
            }
        }

        private PcCategory GetPcCategory(string pcCategoryId) 
        {
            return _context.PcCategory
                        .Where(pc => pc.PC_CATEGORY_ID == int.Parse(pcCategoryId))
                        .FirstOrDefault();
        }
    }
}
