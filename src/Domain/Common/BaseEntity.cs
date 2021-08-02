using System;

namespace CaseCore.Domain.Common
{
    /// <summary>
    /// Abstract base class for Entity classes
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The Id for the Entity
        /// </summary>
        public virtual int Id { get; protected set; }
        /// <summary>
        /// The Timestamp for when the Entity was last modified.
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}
