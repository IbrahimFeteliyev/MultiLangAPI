using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Add any other relevant properties like address, medical history, etc.

        // Navigation property for User's appointments
        public ICollection<Appointment> Appointments { get; set; }
    }
}
