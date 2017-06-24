using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    /// <summary>
    /// Represents a class definition and it is always linked to one practicer. This class has a trainer practicer and it will
    /// be ministered from dateBegin to dateFinish at timeOfDay and specific day of the week.
    /// Example: Pilates, Wednesday at 7:30 ministered by Jos
    /// </summary>
    public class Class : IEntity
    {
        public Guid? id { get; set; }

        public Guid trainerId;
        
        public DateTime dayBegin;

        public DateTime dayEnd;

        public DayOfWeek dayOfWeek;

        public UInt16 timeOfDay;
        
    }
}
