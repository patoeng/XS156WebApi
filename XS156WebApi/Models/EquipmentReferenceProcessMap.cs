using System.Data.Entity.ModelConfiguration;



namespace XS156WebApi.Models
{
    public class EquipmentReferenceProcessMap : EntityTypeConfiguration<EquipmentReferenceProcess>
    {
        public EquipmentReferenceProcessMap()
        {
            HasKey(x => x.Id);
            Property(x => x.LastUpdated);
            Property(x => x.OutputQuantity);
            Property(x => x.RejectedQuantity);
            Property(x => x.ProcessAbleQuantity);
            Property(x => x.ReferenceProcess);
            Property(x => x.Equipment);
            Property(x => x.QuantityLeftToProcess);
            Property(x => x.TargetQuantity);
            Property(x => x.Completed);
            ToTable("EquipmentReferenceProcess");
        } 
    }
}