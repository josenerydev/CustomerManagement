using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Logic.Model
{
    public class IndustryMap : ClassMap<Industry>
    {
        public IndustryMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}
