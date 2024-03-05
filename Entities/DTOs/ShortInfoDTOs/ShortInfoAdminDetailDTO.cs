using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ShortInfoDTOs
{
    public class ShortInfoAdminDetailDTO
    {
        public int Id { get; set; }
        public string Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<string> Title { get; set; }
    }
}
