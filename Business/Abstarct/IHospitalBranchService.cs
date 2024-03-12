using Entities.DTOs.HospitalBranchDTOs;
using Core.Utilities.Results.Abstract;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using Entities.DTOs.ShortInfoDTOs;

namespace Business.Abstarct
{
    public interface IHospitalBranchService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddHospitalBranchByLanguageAsync(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath);
        //Task<Core.Utilities.Results.Abstract.IResult> UpdateCategoryByLanguageAsync(CategoryAdminDetailDTO categoryEditDTO, IFormFile formFile, string webRootPath);
        //Core.Utilities.Results.Abstract.IResult RemoveCategory(int id);
        IDataResult<HospitalBranchDetailDTO> GetHospitalBranchById(int id);
        IDataResult<List<HospitalBranchListDTO>> GetAllHospitalBranchs(string langCode);
        Core.Utilities.Results.Abstract.IResult RemoveHospitalBranch(int id);
    }
}
