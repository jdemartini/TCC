using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class Practicer : IEntity
    {
        public Guid? practicerId { get; set; }
        public string name;
        public string email;

        public Guid? getId()
        {
            return this.practicerId;
        }

        public void setId(Guid id)
        {
            this.practicerId = id;
        }
    }
}
