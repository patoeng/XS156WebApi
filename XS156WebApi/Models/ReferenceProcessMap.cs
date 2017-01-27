using FluentNHibernate.Mapping;

namespace XS156WebApi.Models
{
    public class ReferenceProcessMap : ClassMap<ReferenceProcess>
    {
        public ReferenceProcessMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IsClosed);
            Map(x => x.ProcessGuid);
            Map(x => x.LineGroup);
            Map(x => x.StartDateTime);
            Map(x => x.TargetQuantity);
            Map(x => x.EndDateTime).Nullable().Generated.Insert();;
            Map(x => x.ProductReference);
            Map(x => x.OrderNumber);
            Table("ReferenceProcess");
        }
    }
}