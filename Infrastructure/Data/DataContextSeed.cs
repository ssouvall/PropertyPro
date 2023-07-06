using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context)
        {
            if (!context.CompanyOwners.Any())
            {
                var companyOwnersData = File.ReadAllText("../Infrastructure/Data/SeedData/companyOwners.json");
                var owners = JsonSerializer.Deserialize<List<CompanyOwner>>(companyOwnersData);
                context.CompanyOwners.AddRange(owners);
            }

            if (!context.PrivateOwners.Any())
            {
                var privateOwnersData = File.ReadAllText("../Infrastructure/Data/SeedData/privateOwners.json");
                var owners = JsonSerializer.Deserialize<List<PrivateOwner>>(privateOwnersData);
                context.PrivateOwners.AddRange(owners);
            }

            if (!context.ManagementCompanies.Any())
            {
                var managementCompanyData = File.ReadAllText("../Infrastructure/Data/SeedData/managementCompanies.json");
                var managementCompanies = JsonSerializer.Deserialize<List<ManagementCompany>>(managementCompanyData);
                context.ManagementCompanies.AddRange(managementCompanies);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            if (!context.Properties.Any() && context.ManagementCompanies.Any())
            {
                var propertiesData = File.ReadAllText("../Infrastructure/Data/SeedData/properties.json");
                var properties = JsonSerializer.Deserialize<List<Property>>(propertiesData);
                context.Properties.AddRange(properties);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            if (!context.CompanyOwnerships.Any() && context.CompanyOwners.Any())
            {
                var companyOwnershipData = File.ReadAllText("../Infrastructure/Data/SeedData/companyOwnerships.json");
                var ownerships = JsonSerializer.Deserialize<List<CompanyOwnership>>(companyOwnershipData);
                context.CompanyOwnerships.AddRange(ownerships);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            if (!context.PrivateOwnerships.Any() && context.PrivateOwners.Any())
            {
                var privateOwnershipsData = File.ReadAllText("../Infrastructure/Data/SeedData/privateOwnerships.json");
                var ownerships = JsonSerializer.Deserialize<List<PrivateOwnership>>(privateOwnershipsData);
                context.PrivateOwnerships.AddRange(ownerships);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}