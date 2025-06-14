using Visus.Cuid;
using System.Collections.Generic;
using eClat.Common.Interfaces;


namespace eClat.Common.Entity;

public class Module : EntityBase<string>
{
    public string Name { get; set; }
    public List<Organization> Organizations { get; set; } = new List<Organization>();
}
