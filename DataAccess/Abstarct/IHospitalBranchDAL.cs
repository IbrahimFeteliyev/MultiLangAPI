using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;
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
        List<HospitalBranchListDTO> GetAllHospitalBranchList(string langCode);
    }
}
