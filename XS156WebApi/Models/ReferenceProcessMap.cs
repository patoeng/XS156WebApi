using System.Data.Entity.ModelConfiguration;


namespace XS156WebApi.Models
{
    public class ReferenceProcessMap : EntityTypeConfiguration<ReferenceProcess>
    {
        public ReferenceProcessMap()
        {
            HasKey(x => x.Id);
            Property(x => x.IsClosed);
            Property(x => x.ProcessGuid);
            Property(x => x.LineGroup);
            Property(x => x.StartDateTime);
            Property(x => x.TargetQuantity);
            Property(x => x.EndDateTime);
            Property(x => x.ProductReference);
            Property(x => x.OrderNumber);
            ToTable("ReferenceProcess");
        }
    }
}