using System.Data.Entity.ModelConfiguration;

namespace XS156WebApi.Models
{
    public class EquipmentLineGroupMap : EntityTypeConfiguration<EquipmentLineGroup>
    {
        public EquipmentLineGroupMap()
        {
            HasKey(x => x.Id);
            Property(x => x.LineGroup);
            ToTable("EquipmentLineGroup");
            
        }
    }
}