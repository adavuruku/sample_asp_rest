using eClat.Common.Interfaces;
using Visus.Cuid;

namespace eClat.Common.Entity;

public class Location : EntityBase<string>
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string OrganizationId { get; set; } // Foreign key
    public Organization Organization { get; set; } // Navigation property
}
