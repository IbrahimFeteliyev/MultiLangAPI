using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchListDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string BranchName { get; set; }
        public string HospitalName { get; set; }
        public string Description { get; set; }

        public List<string> PhotoUrl { get; set; }
        public List<HospitalBranchFeatureListDTO> Features { get; set; }

    }
}
