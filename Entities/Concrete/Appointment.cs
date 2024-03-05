using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        // Add any other relevant properties like appointment type, notes, etc.

        // Foreign key for Doctor
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        // Foreign key for User (Patient)
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
