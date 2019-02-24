using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Stock.Models;

namespace Stock.DataAccess
{
    public class StockDataContext : DbContext
    {
        public StockDataContext()
            : base("name=StockDataContext")
        {
        }
        
        public virtual DbSet<CompanyDetailDm> CompanyDetails { get; set; }
        public virtual DbSet<StockPriceDm> StockPrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                       type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}