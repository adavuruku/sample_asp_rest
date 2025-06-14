using eClat.Common.Entity;
using eClat.Common.Interfaces;
using Visus.Cuid;

namespace eclinic.api.Entity
{
    public class Template : EntityBase<string>
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}