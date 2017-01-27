using FluentNHibernate.Mapping;

namespace XS156WebApi.Models
{
    public class EquipmentMap:ClassMap<Equipment>
    {
        public EquipmentMap ()
        {
          
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.EquipmentName);
            Map(x => x.Role);
            Map(x => x.Description);
            Map(x => x.PreviousEquipment);
            Map(x => x.EquipmentLineGroup);
            Map(x => x.Status).Generated.Insert().Default("0");

            Table("Equipment");
        }
    }
}