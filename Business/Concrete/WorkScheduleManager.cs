using Business.Abstarct;
using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkScheduleManager : IWorkScheduleManager
    {
        private readonly IWorkScheduleDal _workScheduleDal;

        public WorkScheduleManager(IWorkScheduleDal workScheduleDal)
        {
            _workScheduleDal = workScheduleDal;
        }

        public WorkSchedule AddWorkSchedule(DateTime workDay, List<DateTime> availableSlots)
        {
            var workSchedule = new WorkSchedule
            {
                WorkDay = workDay,
                AvailableSlots = availableSlots
            };

            _workScheduleDal.Add(workSchedule);
            return workSchedule;
        }

        public WorkSchedule GetWorkScheduleById(int id)
        {
            return _workScheduleDal.Get(ws => ws.Id == id);
        }
    }
}
