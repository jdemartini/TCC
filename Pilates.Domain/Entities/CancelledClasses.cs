﻿using System;
using System.Collections.Generic;

namespace Pilates.Domain.Entities
{
    public class CancelledClasses : IEntity
    {
        public CancelledClasses()
        {
            this.recoveredClasses = new List<Class>();
        }

        public Guid? cancelledClassesId;

        public PracticerClasses practicerClasses;

        public DateTime dateBegin;

        public DateTime dateFinish;

        public bool canRecover;

        public UInt16 quantityOfMissedClasses;

        public List<Class> recoveredClasses;

        public Guid? getId()
        {
            return this.cancelledClassesId;
        }

        public void setId(Guid id)
        {
            this.cancelledClassesId = id;
        }
    }
}