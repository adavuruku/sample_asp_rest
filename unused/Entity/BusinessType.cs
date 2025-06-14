using System.Collections.Generic;
using eClat.Common.Interfaces;
using Visus.Cuid;

namespace eClat.Common.Entity;

public class BusinessType : EntityBase<string>
{
    public string Id { get; set; } = new Cuid2().ToString();
    public string Type { get; set; } // e.g., Public, Private
    public List<Organization> Organizations { get; set; } = new List<Organization>();
}
