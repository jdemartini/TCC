using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    /// <summary>
    /// Represent classes of a trainer. Definition of times of a class and the day of week and it happens.
    /// </summary>
    public class TrainerSchedule : IEntity    
    {
        public Guid? trainerScheduleId;

        public Guid trainerId;

        public DayOfWeek daysOfWeek;

        public uint[] timesOfDay;

        public UInt16 timeMinutesBegin;

        public DateTime dayBegin;

        public DateTime? dayEnd;

        public uint maxNumberOfTrainers;
       
        public Guid? getId()
        {
            return this.trainerScheduleId;
        }

        public void setId(Guid id)
        {
            this.trainerScheduleId = id;
        }
    }       
}
