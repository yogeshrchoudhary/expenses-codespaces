using expenses_api.Endpoints;
using System.Reflection;

namespace expenses_api;

public static class WebApplicationExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        foreach (var endpointDefinitionType in Assembly.GetExecutingAssembly().GetExportedTypes()
            .Where(t => t.IsSubclassOf(typeof(BaseEndpointDefinition))))
        {
            var endpointDefinition = (BaseEndpointDefinition?)Activator.CreateInstance(endpointDefinitionType);
            endpointDefinition?.Map(app);
        }
    }   
}
