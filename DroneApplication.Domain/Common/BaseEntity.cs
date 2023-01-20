using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Domain.Common
{
   public class BaseEntity
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime DateCreated { get; set; }
        public virtual string CreatedBy { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.Now;
            CreatedBy = string.Empty;   
        }

    }
}
