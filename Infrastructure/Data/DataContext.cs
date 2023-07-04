using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<CompanyOwner> CompanyOwners { get; set; }
        public DbSet<PrivateOwner> PrivateOwners { get; set; }
        public DbSet<CompanyOwnership> CompanyOwnerships { get; set; }
        public DbSet<PrivateOwnership> PrivateOwnerships { get; set; }
        public DbSet<ManagementCompany> ManagementCompanies { get; set; }
        public DbSet<PropertyOwnershipStructure> PropertyOwnershipStructures { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyFile> PropertyFiles { get; set; }
    }
}