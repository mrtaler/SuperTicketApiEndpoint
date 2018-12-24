﻿namespace SuperTicketApi.Domain.Seedwork
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class EntityString : Entity, IEntity<string>
    {
        /// <summary>
        /// The requested hash code.
        /// </summary>
        private int? requestedHashCode;

        public string Id { get; set; }

        public bool IsTransient()
        {
            return this.Id == null;
        }

        #region Overrides Methods

        public override bool Equals(object obj)
        {
            var entity = obj as EntityString;
            if (entity == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetRealObjectType(this) != this.GetRealObjectType(obj))
            {
                return false;
            }

            if (this.IsTransient())
            {
                return false;
            }

            return entity.Id == this.Id;

        }

        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this.requestedHashCode.HasValue)
                {
                    this.requestedHashCode =
                        this.Id.GetHashCode()
                        ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }

                return this.requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        public static bool operator ==(EntityString left, EntityString right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(EntityString left, EntityString right)
        {
            return !(left == right);
        }

        #endregion

        private Type GetRealObjectType(object obj)
        {
            var retVal = obj.GetType();

            // because can be compared two object with same id and 'types' but one of it is EF dynamic proxy type)
            if (retVal.GetTypeInfo().BaseType != null && retVal.Namespace == "System.Data.Entity.DynamicProxies")
            {
                retVal = retVal.GetTypeInfo().BaseType;
            }

            return retVal;
        }
    }
}
