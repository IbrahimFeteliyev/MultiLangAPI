using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation property for Doctor's work schedule
        public ICollection<WorkSchedule> WorkSchedules { get; set; }

        // Navigation property for Doctor's appointments
        public ICollection<Appointment> Appointments { get; set; }
    }

}
