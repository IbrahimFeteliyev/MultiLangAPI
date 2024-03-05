using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ShortInfoDTOs
{
    public class ShortInfoDTO
    {
        public record ShortInfoFeaturedDTO(int Id, string Title, string Count);
        public record ShortInfoEditDTO(int Id, string Count, List<ShortInfoEditLanguageDTO> ShortInfoEditLanguageDTOs);
        public record ShortInfoEditLanguageDTO(string Title, string LangCode);
    }
}
