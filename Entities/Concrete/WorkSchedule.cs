using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkSchedule : IEntity
    {
        public int Id { get; set; }
        public DateTime WorkDay { get; set; }
        public ICollection<Appointment> Appointments { get; set; } // Assuming there might be appointments booked for this day
        public List<DateTime> AvailableSlots { get; set; } // List of available appointment slots

        // Foreign key property
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } // Navigation property for Doctor

        public WorkSchedule()
        {
            AvailableSlots = new List<DateTime>();
        }
    }

}
