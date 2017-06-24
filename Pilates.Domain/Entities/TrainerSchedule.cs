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
        public Guid? id { get; set; }

        public Guid trainerId;

        public DayOfWeek dayOfWeek;

        public uint[] timesOfDay;

        public UInt16 timeMinutesBegin;

        public DateTime dayBegin;

        public DateTime? dayEnd;

        public uint maxNumberOfTrainers;
       
     
    }       
}
