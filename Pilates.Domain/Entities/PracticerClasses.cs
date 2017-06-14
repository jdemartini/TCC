using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    /// <summary>
    /// Represents when a practicer will have his classes. 
    /// Practicer can have more than 1 class a week 
    /// Example: Jos has classes on Mondays, 7AM and Wednesday, 6AM.
    /// </summary>
    public class PracticerClasses : IEntity
    {
        public PracticerClasses()
        {
            this.classes = new List<Class>();
        }

        public Guid? practicerClassesId;

        public Guid practicerId;

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
