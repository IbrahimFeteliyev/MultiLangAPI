﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HospitalBranch : BaseEntity, IEntity
    {
        public string CoverPhoto { get; set; }
        public List<HospitalBranchPhoto> HospitalBranchPhotos { get; set; } = new List<HospitalBranchPhoto>();
        public List<HospitalBranchLanguage> HospitalBranchLanguages { get; set; } = new List<HospitalBranchLanguage>();
        public List<HospitalBranchFeature> HospitalBranchFeatures { get; set; } = new List<HospitalBranchFeature>();
    }
}
