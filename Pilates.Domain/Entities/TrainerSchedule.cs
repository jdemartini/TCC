using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class TrainerSchedule : IEntity    
    {
        public Guid? trainerScheduleId;

        public Trainer trainer;

        public uint timesOfDay;

        public UInt16 timeMinutesBegin;

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
