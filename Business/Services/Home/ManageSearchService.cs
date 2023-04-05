using System;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;

namespace eComMaster.Business.Services.Home
{
	public class ManageSearchService: IManageSearchService
    {
        private readonly ApplicationDbContext applicatiobDbContext;

        public ManageSearchService(ApplicationDbContext applicatiobDbContext)
        {
            this.applicatiobDbContext = applicatiobDbContext;
        }

        public List<PcModel> SearchModels(string term) {
            // Perform search logic here, e.g. querying the database
            // based on the search term and retrieving matching models
            var matchingModels = applicatiobDbContext.PcModel
                .Where(m => m.PC_MODEL_NAME.Contains(term))
                .ToList();
          
            return matchingModels;
        }
    }
}

