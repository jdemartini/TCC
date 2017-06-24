using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class Schedule : IEntity
    {
        public Guid? id { get; set; }

        public DateTime begin;

        public DateTime finish;

        public DayOfWeek dayOfWeek;

        public UInt32 timesOfDay;
        
    }
}
