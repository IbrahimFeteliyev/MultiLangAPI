using Entities.DTOs.HospitalBranchDTOs;
using Core.Utilities.Results.Abstract;

namespace Business.Abstarct
{
    public interface IHospitalBranchService
    {
        Task<Core.Utilities.Results.Abstract.IResult> AddHospitalBranchByLanguageAsync(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath);
        IDataResult<List<HospitalBranchListDTO>> GetAllHospitalBranchs(string langCode);

    }
}
