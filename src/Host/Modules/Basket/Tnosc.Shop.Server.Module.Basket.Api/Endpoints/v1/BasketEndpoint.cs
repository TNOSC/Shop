using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Tnosc.Components.Abstractions.Api;

namespace Tnosc.Shop.Server.Module.Basket.Api.Endpoints.v1;
public class BasketEndpoint : EndpointBase
{
    public BasketEndpoint()
        : base("api/v{version:apiVersion}/baskets") => WithTags("Basket");

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new Asp.Versioning.ApiVersion(1))
            .ReportApiVersions()
            .Build();

        app.MapGet("checkpoint", CheckEndpoint)
        .Produces(200, typeof(string))
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Check API Health",
            Description = "This endpoint is used to check if the Basket API is up and running."
        }).WithApiVersionSet(apiVersionSet);
    }

    private static IResult CheckEndpoint(ILogger<BasketEndpoint> logger)
    {
        logger.LogInformation("CheckEndpoint has been called");
        return Results.Ok("Basket API");
    }
}
