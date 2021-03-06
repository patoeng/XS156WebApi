﻿using FluentNHibernate.Mapping;
using NHibernate.Dialect;
using NHibernate.Mapping;

namespace XS156WebApi.Models
{
    public class EquipmentLineGroupMap : ClassMap<EquipmentLineGroup>
    {
        public EquipmentLineGroupMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.LineGroup);
            Table("EquipmentLineGroup");
            
        }
    }
}