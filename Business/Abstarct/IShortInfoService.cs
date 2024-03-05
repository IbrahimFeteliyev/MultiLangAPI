using Core.Utilities.Results.Abstract;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.ShortInfoDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IShortInfoService
    {
        IDataResult<List<ShortInfoAdminListDTO>> GetAllShortInfosAdmin(string langCode);
        Task<Core.Utilities.Results.Abstract.IResult> AddShortInfoByLanguageAsync(ShortInfoAddDTO shortInfoAddDTO);
        Task<Core.Utilities.Results.Abstract.IResult> UpdateShortInfoByLanguageAsync(ShortInfoUpdateDTO shortInfoUpdateDTO, int Id);
        IDataResult<ShortInfoAdminDetailDTO> GetShortInfoById(int id);
        Core.Utilities.Results.Abstract.IResult RemoveShortInfo(int id);
    }
}
