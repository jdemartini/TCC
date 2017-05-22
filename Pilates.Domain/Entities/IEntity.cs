using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public interface IEntity
    {
        Guid? getId();
        void setId(Guid id);
    }
}
