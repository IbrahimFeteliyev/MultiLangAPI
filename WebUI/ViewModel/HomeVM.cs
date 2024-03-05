using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace WebUI.ViewModel
{
    public class HomeVM
    {
        public List<CategoryFeaturedDTO> CategoryFeatureds { get; set; }
    }
}
