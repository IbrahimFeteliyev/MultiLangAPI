using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IWorkScheduleManager
    {
        WorkSchedule AddWorkSchedule(DateTime workDay, List<DateTime> availableSlots);
        WorkSchedule GetWorkScheduleById(int id);
    }
}
