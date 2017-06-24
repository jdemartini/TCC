using System;
using System.Collections.Generic;
using System.Text;

namespace Pilates.Account.Domain.Entities
{
    public class User : IEntity
    {
        public Guid? id { get; set; }
        public string name;
        public string email;
        public string phone;
        public DateTime bornDate;
    }
}
