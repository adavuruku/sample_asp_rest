using Visus.Cuid;

using eClat.Common.Model.Enum;

namespace eClat.Common.Entity;

using System;
using System.Collections.Generic;
using eClat.Common.Interfaces;

public class Application : EntityBase<string>
{
    public Application()
    {
        ApplicationStatus = ApplicationStatus.InActive;
    }

    public string Name { get; set; }
    public ApplicationStatus ApplicationStatus { get; set; }
    public string Mode { get; set; } // SAAS, Dedicated
    public string Description { get; set; }
    public string OrgId { get; set; }
    public List<Organization> Organizations { get; set; } = new List<Organization>(); // For many-to-many
}
