using FluentNHibernate.Mapping;

namespace XS156WebApi.Models
{
    public class ProductReferenceMap : ClassMap<ProductReference>
    {
        public ProductReferenceMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.ReferenceName);
            Map(x => x.Descriptions);
            Map(x => x.GroupingSize).Nullable();
            Table("ProductReference");
        }
    }
}