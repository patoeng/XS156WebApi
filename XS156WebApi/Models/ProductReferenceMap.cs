using System.Data.Entity.ModelConfiguration;


namespace XS156WebApi.Models
{
    public class ProductReferenceMap : EntityTypeConfiguration<ProductReference>
    {
        public ProductReferenceMap()
        {
            HasKey(x => x.Id);
            Property(x => x.ReferenceName);
            Property(x => x.Descriptions);
            Property(x => x.GroupingSize);
            ToTable("ProductReference");
        }
    }
}