
using System;
using System.Collections.Generic;
using eClat.Common.Interfaces;
using Visus.Cuid;

namespace eClat.Common.Entity;


public class Branch : EntityBase<string>
{
    public string Id { get; set; } = new Cuid2().ToString();
    public string Name { get; set; }
    public List<Organization> Organizations { get; set; } = new List<Organization>();
  
}
