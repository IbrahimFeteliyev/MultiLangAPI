using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddWorkScheduleDTO
    {
        public DateTime WorkDay { get; set; }
        public List<DateTime> AvailableSlots { get; set; }
    }

}
