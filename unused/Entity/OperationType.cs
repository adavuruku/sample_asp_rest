using Visus.Cuid;
using System.Collections.Generic;
using eClat.Common.Interfaces;


namespace eClat.Common.Entity;

public class OperationType : EntityBase<string>
{
    public string Type { get; set; } // e.g., Hybrid, LocalOnly, OnlineOnly
    public List<Organization> Organizations { get; set; } = new List<Organization>();
}
