using Business.Abstarct;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public Doctor AddDoctor(DoctorDTO doctorDto)
        {
            var doctor = new Doctor 
            {
                Name = doctorDto.Name,
                Email = doctorDto.Email,
                Password = doctorDto.Password,
            };

            _doctorDal.Add(doctor);
            return doctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorDal.GetAll();
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorDal.Get(d => d.Id == id);
        }

        public Doctor LoginDoctor(LoginDTO loginDTO)
        {
            return _doctorDal.Get(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
        }

    }
}
