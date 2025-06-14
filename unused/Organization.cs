using eClat.Common.Entity;
using eClat.Common.Interfaces;
using Visus.Cuid;
using eClat.Common.Model.Enum;

namespace eclinic.api.Entity;

public class Organization : EntityBase<string>
{
    public string Subdomain { get; set; }

    public string OrgToken { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public string ShortName { get; set; }
    public string Description { get; set; }

    public string Url { get; set; }

    public string DatabaseType { get; set; } // MySQL or Postgres
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    
    public OrganizationStatus OrganizationStatus { get; set; }
}
