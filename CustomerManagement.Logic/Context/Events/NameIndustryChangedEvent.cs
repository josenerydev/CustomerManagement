using CustomerManagement.Logic.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.Model
{
    public class NameIndustryChangedEvent : IDomainEvent
    {
        public string Name { get; private set; }

        public NameIndustryChangedEvent(string name)
        {
            Name = name;
        }
    }
}
