

using System.Data.Entity.ModelConfiguration;


namespace XS156WebApi.Models
{
    public class EquipmentMap : EntityTypeConfiguration<Equipment>
    {
        public EquipmentMap ()
        {

            HasKey(x => x.Id);
            Property(x => x.EquipmentName);
            Property(x => x.Role);
            Property(x => x.Description);
            Property(x => x.PreviousEquipment);
            Property(x => x.EquipmentLineGroup);
            Property(x => x.Status);

            ToTable("Equipment");
        }
    }
}