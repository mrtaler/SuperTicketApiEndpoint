namespace SuperTicketApi.Domain.Seedwork
{
    using System;

    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class EntityGuid : Entity, IEntity<Guid>
    {
        #region Members

        /// <summary>
        /// The requested hash code.
        /// </summary>
        private int? requestedHashCode;

        /// <summary>
        /// The id.
        /// </summary>
        private Guid id;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets persistent object identifier
        /// </summary>
        public virtual Guid Id
        {
            get => this.id;
            set => this.id = value;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return this.Id == Guid.Empty;
        }

        /// <summary>
        /// Generate identity for this entity
        /// </summary>
        public void GenerateNewIdentity()
        {
            if (this.IsTransient())
            {
                this.Id = IdentityGenerator.NewSequentialGuid();
            }
        }

        /// <summary>
        /// Change current identity for a new non transient identity
        /// </summary>
        /// <param name="identity">the new identity</param>
        public void ChangeCurrentIdentity(Guid identity)
        {
            if (identity != Guid.Empty)
            {
                this.Id = identity;
            }
        }

        #endregion

        #region Overrides Methods

        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/></param>
        /// <returns><see cref="M:System.Object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityGuid))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            EntityGuid item = (EntityGuid)obj;

            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return item.Id == this.Id;
            }
        }

        /// <summary>
        /// <see cref="M:System.Object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="M:System.Object.GetHashCode"/>hash</returns>
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

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator ==(EntityGuid left, EntityGuid right)
        {
            if (object.Equals(left, null))
            {
                return object.Equals(right, null) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(EntityGuid left, EntityGuid right)
        {
            {
                return !(left == right);
            }
        }

        #endregion
    }
}
