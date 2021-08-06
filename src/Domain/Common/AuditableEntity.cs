using System;

namespace CaseCore.Domain.Common
{
    /// <summary>
    /// Abstract class for an Entity that needs audit information
    /// </summary>
    public abstract class AuditableEntity : BaseEntity
    {
        /// <summary>
        /// The username of the User who created the Entity.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The Timestamp for when the Entity was created.
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// The username of the User who last modified the Entity.
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}
