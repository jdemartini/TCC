using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class Schedule : IEntity
    {
        public Guid? scheduleId;

        public DateTime begin;

        public DateTime finish;

        public DayOfWeek dayOfWeek;

        public UInt32 timesOfDay;

        public Guid? getId()
        {
            return this.scheduleId;
        }

        public void setId(Guid id)
        {
            this.scheduleId = id;
        }
    }
}
