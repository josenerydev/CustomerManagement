using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.SeedWork
{
    public abstract class Enumeration : AggregateRoot
    {
        public virtual string Name { get; protected set; }
    }
}
