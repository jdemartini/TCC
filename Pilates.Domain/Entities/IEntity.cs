using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Domain.Entities
{
    public interface IEntity
    {
        Guid? id { get; set; }
    }
}
