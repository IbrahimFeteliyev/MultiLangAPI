using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IDoctorManager
    {
        Doctor LoginDoctor(LoginDTO loginDTO);
        Doctor AddDoctor(DoctorDTO doctorDto);
        Doctor GetDoctorById(int id);
        List<Doctor> GetAllDoctors();
    }
}
