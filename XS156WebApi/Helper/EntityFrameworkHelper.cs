using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XS156WebApi.Models;

namespace XS156WebApi.Helper
{
    public class EntityFrameworkHelper
    {
        public static string DbConnection =@"Data Source=127.0.0.1;Initial Catalog=XS156TRAC;User ID=sa;Password=passwordsa;";
    }
     public class Xs156DbContext : DbContext
        {
            // Tell EF that the User class needs to be mapped using the default conventions
            public DbSet<Equipment> Equipment { get; set; }
            public DbSet<EquipmentLineGroup> EquipmentLineGroup { get; set; }
            public DbSet<EquipmentReferenceProcess> EquipmentReferenceProcess { get; set; }
            public DbSet<ProductReference> ProductReference { get; set; }
            public DbSet<ReferenceProcess> ReferenceProcess { get; set; }

            public Xs156DbContext()
                : base(EntityFrameworkHelper.DbConnection) { }
           

          //  public Xs156DbContext(string nameOrConnectionString)
          //      : base(nameOrConnectionString) {}

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Specify mapping overrides
                modelBuilder.Configurations.Add(new EquipmentMap());
                modelBuilder.Configurations.Add(new EquipmentLineGroupMap());
                modelBuilder.Configurations.Add(new EquipmentReferenceProcessMap());
                modelBuilder.Configurations.Add(new ProductReferenceMap());
                modelBuilder.Configurations.Add(new ReferenceProcessMap());
            }
        }

}