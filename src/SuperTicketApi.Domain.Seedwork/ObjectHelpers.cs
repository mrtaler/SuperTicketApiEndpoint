namespace SuperTicketApi.Domain.Seedwork
{
    /// <summary>
    /// The object helpers.
    /// </summary>
    public static class ObjectHelpers
    {
        public static bool ObjectEquals(this object first, object second)
        {
            if (first == null && second != null || first != null && second == null)
                return false;
            if (first == null && second == null)
                return true;
            return first.Equals(second);
        }
    }
}