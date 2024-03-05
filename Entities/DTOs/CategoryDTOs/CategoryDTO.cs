using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        public record CategoryFeaturedDTO(int Id, string CategoryName, string PhotoUrl);
        public record CategoryEditDTO(int Id, bool IsFeatured, string PhotoUrl, List<CategoryEditLanguageDTO> CategoryEditLanguageDTOs);
        public record CategoryEditLanguageDTO(string CategoryName, string LangCode);
    }
}
