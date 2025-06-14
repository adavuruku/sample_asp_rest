using eClat.Common.Interfaces;
using eClat.Common.Model.Enum;
using Visus.Cuid;

namespace eClat.Common.Entity;

public class Organization : EntityBase<string>
{
    public Organization()
    {
        OrganizationStatus = OrganizationStatus.Pending;
        BusinessTypes = new List<BusinessType>();
        OperationTypes = new List<OperationType>();
        Applications = new List<Application>();
        Branches = new List<Branch>();
        Products = new List<Product>();
        ModulesEnabled = new List<Module>();
        Since = DateTime.UtcNow;
    }

    public string Subdomain { get; set; }
    public string OrgId { get; set; }
    public string OrgType { get; set; } // Hospital, Analytics, Lab, Pharmacy
    public List<BusinessType> BusinessTypes { get; set; } // Public, Private
    public List<OperationType> OperationTypes { get; set; } // Hybrid, LocalOnly, OnlineOnly
    public string OrgToken { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }
    public string PhoneNumbers { get; set; }
    public Contact Contact { get; set; }
    public Location Location { get; set; }
    public DateTime? Since { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    public List<Application> Applications { get; set; } // Navigation property for many-to-many
    public Application PrimaryApplication { get; set; } // Renamed to avoid conflict
    public string Url { get; set; }
    public OrganizationStatus OrganizationStatus { get; set; }
    public bool ERPIntegrationEnabled { get; set; }
    public bool BranchEnabled { get; set; }
    public List<Branch> Branches { get; set; }
    public string DatabaseType { get; set; } // MySQL or Postgres
    public string ConnectionString { get; set; }
    public List<Product> Products { get; set; } // Lite, Plus, Pro, V3
    public List<Module> ModulesEnabled { get; set; }
    public string DatabaseName { get; set; }
}
