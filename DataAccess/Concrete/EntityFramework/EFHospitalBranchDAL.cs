using Core.DataAccess.EntityFramework;
using Core.Helper;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.HospitalBranchDTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFHospitalBranchDAL : EfEntityRepositoryBase<HospitalBranch, AppDbContext>, IHospitalBranchDAL
    {
        public async Task<bool> AddHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                HospitalBranch hospitalBranch = new()
                {
                    CoverPhoto = await hospitalBranchAddDTO.CoverPhoto.SaveFileAsync(webRootPath),
                };

                //await context.HospitalBranchs.AddAsync(hospitalBranch);
                //await context.SaveChangesAsync();

                for (int i = 0; i < hospitalBranchAddDTO.BranchName.Count; i++)
                {
                    HospitalBranchLanguage hospitalBranchLanguage = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        BranchName = hospitalBranchAddDTO.BranchName[i],
                        HospitalName = hospitalBranchAddDTO.HospitalName[i],
                        Description = hospitalBranchAddDTO.Description[i],
                        LangCode = hospitalBranchAddDTO.LangCode[i]
                    };

                    hospitalBranch.HospitalBranchLanguages.Add(hospitalBranchLanguage);
                    //await context.HospitalBranchLanguages.AddAsync(hospitalBranchLanguage);
                }

                for (int i = 0; i < hospitalBranchAddDTO.HospitalBranchFeatures.Count; i++)
                {
                    HospitalBranchFeature hospitalBranchFeature = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        Number = hospitalBranchAddDTO.HospitalBranchFeatures[i].Number,
                        PhotoUrl = await hospitalBranchAddDTO.HospitalBranchFeatures[i].FeaturePhotoUrl.SaveFileAsync(webRootPath),
                    };
                    await context.HospitalBranchFeatures.AddAsync(hospitalBranchFeature);

                    for (int j = 0; j < hospitalBranchAddDTO.HospitalBranchFeatures[i].FeatureDescription.Count; j++)
                    {
                        HospitalBranchFeatureLanguage hospitalBranchFeatureLanguage = new()
                        {
                            HospitalBranchFeatureId = hospitalBranchFeature.Id,
                            Description = hospitalBranchAddDTO.HospitalBranchFeatures[i].FeatureDescription[j],
                            LangCode = hospitalBranchAddDTO.LangCode[j]
                        };
                        hospitalBranchFeature.HospitalBranchFeatureLanguages.Add(hospitalBranchFeatureLanguage);
                        //await context.HospitalBranchFeatureLanguages.AddAsync(hospit
                        //alBranchFeatureLanguage);
                    }

                    hospitalBranch.HospitalBranchFeatures.Add(hospitalBranchFeature);
                }

                for (int i = 0; i < hospitalBranchAddDTO.PhotoUrl.Count; i++)
                {
                    HospitalBranchPhoto hospitalBranchPhoto = new()
                    {
                        HospitalBranchId = hospitalBranch.Id,
                        PhotoUrl = await hospitalBranchAddDTO.PhotoUrl[i].SaveFileAsync(webRootPath),
                    };
                    hospitalBranch.HospitalBranchPhotos.Add(hospitalBranchPhoto);
                    //await context.HospitalBranchPhotos.AddAsync(hospitalBranchPhoto);
                }

                await context.HospitalBranchs.AddAsync(hospitalBranch);

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<HospitalBranchListDTO> GetAllHospitalBranchList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.HospitalBranchs.Select(x => new HospitalBranchListDTO
            {
                Id = x.Id,
                BranchName = x.HospitalBranchLanguages.FirstOrDefault(x => x.LangCode == langCode).BranchName,
                HospitalName = x.HospitalBranchLanguages.FirstOrDefault(x => x.LangCode == langCode).HospitalName,
                Description = x.HospitalBranchLanguages.FirstOrDefault(x => x.LangCode == langCode).Description,
                PhotoUrl = x.HospitalBranchPhotos.Select(x => x.PhotoUrl).ToList(),
                CoverPhoto = x.CoverPhoto,
                Features = x.HospitalBranchFeatures.Select(f => new HospitalBranchFeatureListDTO
                {
                    Number = f.Number,
                    FeatureDescription = f.HospitalBranchFeatureLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.Description)
                                         .ToList(),
                    FeaturePhotoUrl = f.PhotoUrl
                }).ToList()
            }).ToList();

            return result;
        }
    }
}
