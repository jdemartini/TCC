using System;
using System.Collections.Generic;

namespace Pilates.Domain.Entities
{

    /// <summary>
    /// Represent cancelled class and if it was fully recovered. It is possible to cancel multiple classes as it is possible to recover all.
    /// </summary>
    public class CancelledClasses : IEntity
    {
        public CancelledClasses()
        {
            this.recoveredClasses = new List<Class>();
        }

        public Guid? id { get; set; }

        public PracticerClasses practicerClasses;

        public DateTime dateBegin;

        public DateTime dateFinish;

        public bool canRecover;

        public UInt16 quantityOfMissedClasses;

        public List<Class> recoveredClasses;

        
    }
}