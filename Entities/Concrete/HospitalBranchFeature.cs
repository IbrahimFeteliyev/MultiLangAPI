using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HospitalBranchFeature: BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public string Number { get; set; } 
        public int HospitalBranchId { get; set; }
        public HospitalBranch HospitalBranch { get; set; }
        public List<HospitalBranchFeatureLanguage> HospitalBranchFeatureLanguages { get; set; } = new List<HospitalBranchFeatureLanguage>();
    }
}
