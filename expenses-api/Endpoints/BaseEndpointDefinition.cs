
namespace expenses_api.Endpoints;

public abstract class BaseEndpointDefinition
{
    public abstract void Map(IEndpointRouteBuilder app);
}