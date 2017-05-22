using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public class PracticerClasses : IEntity
    {
        public PracticerClasses()
        {
            this.classes = new List<Class>();
        }

        public Guid? practicerClassesId;

        public Practicer practicer;

        public List<Class> classes;

        public Guid? getId()
        {
            return this.practicerClassesId;
        }

        public void setId(Guid id)
        {
            this.practicerClassesId = id;
        }

    }
}
