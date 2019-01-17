namespace SuperTicketApi.Domain.Seedwork
{
    /// <summary>
    /// The parameter.
    /// </summary>
    public class Parameter
    {
        public string Key { get; set; }

        public object Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public Parameter(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }

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
            if (this == obj)
                return true;
            Parameter parameter = obj as Parameter;
            if (parameter == null || !(this.Key == parameter.Key))
                return false;
            return this.Value.ObjectEquals(parameter.Value);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return (37 * 23 + this.Key.GetHashCode()) * 23 + this.Value.GetHashCode();
        }
    }
}