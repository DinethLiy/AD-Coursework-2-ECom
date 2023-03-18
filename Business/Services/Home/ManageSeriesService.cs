using System;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using System.Collections.Generic;
using eComMaster.Models.MasterData;

namespace eComMaster.Business.Services.Home
{
	public class ManageSeriesService: IManageSeriesService
    {
		private readonly ApplicationDbContext applicationDbContext;
       // private readonly string _categoryId;

      

        public ManageSeriesService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
          //  this._categoryId = categoryId;
        }
        public List<PcSeries> GetPcSeries(string categoryId) {
            int categoryIdInt = Convert.ToInt32(categoryId);
            var seriesList = applicationDbContext.PcSeries
                .Where(x => x.PC_CATEGORY_ID.PC_CATEGORY_ID == categoryIdInt &&
                            x.PC_SERIES_STATUS != "INA" &&
                            x.DELETED_BY == null)
                .ToList();


            return seriesList;
        }

      
    }
}

