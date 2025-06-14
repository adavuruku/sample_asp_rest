using eClat.Common.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Visus.Cuid;

namespace eClat.Common.Entity
{
    public class EntityBase<TId> : IEntityBase<TId>
    {
        
        [Key]
        public TId Id { get; set; }
        public DateTime CreateDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdateDate { get; set; }
        
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        

        public EntityBase()
        {
            CreateDate = DateTime.UtcNow;

            // Only generate CUID if TId is string
            if (typeof(TId) == typeof(string))
            {
                // Set Id using reflection to bypass generic constraint
                Id = (TId)(object) new Cuid2().ToString(); // or Cuid.CreateCuid() if using RobThree.Cuid
            }
        }
    }
}