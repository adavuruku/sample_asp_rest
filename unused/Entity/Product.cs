namespace eClat.Common.Entity;

using Visus.Cuid;
using System.Collections.Generic;
using eClat.Common.Interfaces;

public class Product : EntityBase<string>
{
    public string Name { get; set; } // e.g., Lite, Plus, Pro, V3
    public List<Organization> Organizations { get; set; } = new List<Organization>();
}
