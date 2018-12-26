namespace SuperTicketApi.DistributedServices.Seedwork
{
    using System.Linq;

    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using TupleExtensions;

    /// <summary>
    /// d d
    /// </summary>
    public class VersionFilter : IDocumentFilter, IOperationFilter
    {
        /// <summary>
        /// Method for apply new version for Document Filter Context.
        /// </summary>
        /// <param name="swaggerDoc">
        /// The swagger doc.
        /// </param>
        /// <param name="context">
        /// The <c>context</c>.
        /// </param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths = swaggerDoc.Paths
                .Select(kvp =>
                    {
                        var (path, pathItem) = kvp;
                        path = path.Replace("{version}", swaggerDoc.Info.Version);
                        return (path, pathItem);
                    }).ToDictionary();
        }

        /// <summary>
        /// Method for apply new version for Operation Filter Context.
        /// </summary>
        /// <param name="operation">
        /// The <paramref name="operation"/>.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.First(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }
}