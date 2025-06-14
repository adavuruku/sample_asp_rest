using eClat.Common.Interfaces;
using Visus.Cuid;

namespace eClat.Common.Entity;

public class Contact : EntityBase<string>
{
    public string Id { get; set; } = new Cuid2().ToString();
    public string Name { get; set; }
    public string Title { get; set; }
    public string Email { get; set; }
    public string PhoneNumbers { get; set; }
    public string OrganizationId { get; set; } // Foreign key
    public Organization Organization { get; set; } // Navigation property
}
