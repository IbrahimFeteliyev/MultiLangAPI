using Business.Abstarct;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.ErrorResults;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;
using Entities.DTOs.ShortInfoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.Abstract.IResult;

namespace Business.Concrete
{
    public class HospitalBranchManager : IHospitalBranchService
    {
        private readonly IHospitalBranchDAL _hospitalBranchDAL;

        public HospitalBranchManager(IHospitalBranchDAL hospitalBranchDAL)
        {
            _hospitalBranchDAL = hospitalBranchDAL;
        }

        public async Task<IResult> AddHospitalBranchByLanguageAsync(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath)
        {
            var result = await _hospitalBranchDAL.AddHospitalBranch(hospitalBranchAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("HospitalBranch created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
        public IDataResult<List<HospitalBranchListDTO>> GetAllHospitalBranchs(string langCode)
        {
            try
            {
                var result = _hospitalBranchDAL.GetAllHospitalBranchList(langCode);
                return new SuccessDataResult<List<HospitalBranchListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<HospitalBranchListDTO>>(ex.Message);
            }
        }

        public IDataResult<HospitalBranchDetailDTO> GetHospitalBranchById(int id)
        {
            var result = _hospitalBranchDAL.GetHospitalBranchByIdAdmin(id);
            return new SuccessDataResult<HospitalBranchDetailDTO>(result);
        }
        public IResult RemoveHospitalBranch(int id)
        {
            var hospitalBranch = _hospitalBranchDAL.Get(x => x.Id == id);
            _hospitalBranchDAL.Delete(hospitalBranch);
            return new SuccessResult("Deleted Successfully");
        }
    }
}
