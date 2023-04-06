using System;
using System.Collections.Generic;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using eComMaster.Models.MasterData;
using Microsoft.EntityFrameworkCore;

namespace eComMaster.Business.Services.Home
{
    public class ManageHomeService : IManageHomeService
	{
        private readonly ApplicationDbContext _context;
        public ManageHomeService(ApplicationDbContext context)
		{
            _context = context;
        }
        public List<PcCategory> GetPcCategories() {
            List<PcCategory> categories = _context.PcCategory.ToList();
            return categories;
        }
        

    }
}

