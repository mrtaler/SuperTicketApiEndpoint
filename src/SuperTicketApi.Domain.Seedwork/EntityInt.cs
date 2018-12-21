﻿namespace SuperTicketApi.Domain.Seedwork
{
    using System;

    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class EntityInt : Entity, IEntity<int>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as EntityInt);
        }

        /// <summary>
        /// The is transient.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsTransient(EntityInt obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        /// <summary>
        /// The get unproxied type.
        /// </summary>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        private Type GetUnproxiedType()
        {
            return this.GetType();
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public virtual bool Equals(EntityInt other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(this.Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = this.GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(this.Id, default(int)))
            {
                return base.GetHashCode();
            }

            return this.Id.GetHashCode();
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator ==(EntityInt x, EntityInt y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(EntityInt x, EntityInt y)
        {
            return !(x == y);
        }
    }
}
