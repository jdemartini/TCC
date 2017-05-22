using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class Class : IEntity
    {
        public Guid? classId;

        public Trainer trainer;

        public DateTime dateBegin;

        public DateTime dateFinish;

        public DayOfWeek dayOfWeek;

        public TimeSpan timeOfDay;

        public Guid? getId()
        {
            return this.classId;
        }

        public void setId(Guid id)
        {
            this.classId = id;
        }
    }
}
