using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.ShortInfoDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace DataAccess.Abstarct
{
    public interface IShortInfoDAL : IEntityRepository<ShortInfo>
    {
        Task<bool> AddShortInfo(ShortInfoAddDTO shortInfoAddDTO);
        Task<bool> UpdateShortInfo(ShortInfoUpdateDTO shortInfoUpdateDTO, int Id);
        List<ShortInfoAdminListDTO> GetAllShortInfosAdminList(string langCode);
        ShortInfoAdminDetailDTO GetShortInfoByIdAdmin(int id);
    }
}
