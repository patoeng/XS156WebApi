using FluentNHibernate.Mapping;


namespace XS156WebApi.Models
{
    public class EquipmentReferenceProcessMap : ClassMap<EquipmentReferenceProcess>
    {
        public EquipmentReferenceProcessMap()
        {
            Id(x => x.Id);
            Map(x => x.LastUpdated).Generated.Insert();
            Map(x => x.OutputQuantity);
            Map(x => x.RejectedQuantity);
            Map(x => x.ProcessAbleQuantity);
            Map(x => x.ReferenceProcess);
            Map(x => x.Equipment);
            Map(x => x.QuantityLeftToProcess);
            Map(x => x.TargetQuantity);
            Map(x => x.Completed).Nullable();
            Table("EquipmentReferenceProcess");
        } 
    }
}