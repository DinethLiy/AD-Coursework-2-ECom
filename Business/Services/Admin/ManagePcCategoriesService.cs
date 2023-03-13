using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using eComMaster.Models.MasterData;
using System.Collections;

namespace eComMaster.Business.Services.Admin
{
    public class ManagePcCategoriesService : IManagePcCategoriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManagePcCategoriesService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<PcCategory> GetPcCategoriesList()
        {
            return _context.PcCategory
                .Where(pc => pc.DELETED_BY == null)
                .ToList();
        }

        public PcCategory? GetTempDataForAddEditPcCategory(int pcCategoryId)
        {
            if (pcCategoryId != -1)
            {
                return _context.PcCategory
                    .Where(pc => pc.PC_CATEGORY_ID == pcCategoryId)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public string AddPcCategory(string accessToken, string categoryName, string? categoryDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            PcCategory newCategory = new()
            {
                PC_CATEGORY_NAME = categoryName,
                PC_CATEGORY_STATUS = "ACT",
                CREATED_BY = foundUser,
                CREATED_DATE = DateTime.Now,
            };
            newCategory.PC_CATEGORY_DESCRIPTION = categoryDesc;
            _context.PcCategory.Add(newCategory);
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

        public string EditPcCategory(string accessToken, string pcCategoryId, string categoryName, string status, string? categoryDesc)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundCategory = _context.PcCategory
                        .Where(pc => pc.PC_CATEGORY_ID == int.Parse(pcCategoryId))
                        .FirstOrDefault();
            foundCategory.PC_CATEGORY_NAME = categoryName;
            foundCategory.PC_CATEGORY_STATUS = status;
            foundCategory.PC_CATEGORY_DESCRIPTION = categoryDesc;
            foundCategory.MODIFIED_BY = foundUser;
            foundCategory.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return pcCategoryId;
            }
        }

        public string DeletePcCategory(string accessToken, string pcCategoryId)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundCategory = _context.PcCategory
                        .Where(pc => pc.PC_CATEGORY_ID == int.Parse(pcCategoryId))
                        .FirstOrDefault();
            foundCategory.PC_CATEGORY_STATUS = "INA";
            foundCategory.DELETED_BY = foundUser;
            foundCategory.DELETED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return pcCategoryId;
            }
        }
    }
}
