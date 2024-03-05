using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchFeatureListDTO
    {
        public string Number { get; set; }
        public List<string> FeatureDescription { get; set; }
        public string FeaturePhotoUrl { get; set; }
    }
}
