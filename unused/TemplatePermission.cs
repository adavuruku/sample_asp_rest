using eClat.Common.Entity;
using eClat.Common.Interfaces;
using Visus.Cuid;

namespace eclinic.api.Entity
{
    public class TemplatePermission : EntityBase<string>
    {
        public string ModuleId { get; set; }
        public Module Module { get; set; }

        public string ActionGroupId { get; set; }
        public ActionGroup ActionGroup { get; set; }

        public string ActionPermissionId { get; set; }
        public ActionPermission ActionPermission { get; set; }

        public string TemplateId { get; set; }
        public Template Template { get; set; }
    }
}