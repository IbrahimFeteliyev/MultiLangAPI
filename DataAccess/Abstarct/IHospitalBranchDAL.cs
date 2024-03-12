using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IHospitalBranchDAL : IEntityRepository<HospitalBranch>
    {
        Task<bool> AddHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath);
        //Task<bool> UpdateCategory(CategoryAdminDetailDTO categoryEditDTO, IFormFile formFile, string webRootPath);
        HospitalBranchDetailDTO GetHospitalBranchByIdAdmin(int id);
        List<HospitalBranchListDTO> GetAllHospitalBranchList(string langCode);
    }
}
