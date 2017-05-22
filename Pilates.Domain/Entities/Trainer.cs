using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class Trainer : IEntity
    {
        public Guid? trainerId;
        public string name;
        public string email;

        public Guid? getId()
        {
            return this.trainerId;
        }

        public void setId(Guid id)
        {
            this.trainerId = id;
        }
    }
}
