using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Tnosc.Components.Abstractions.Api;

namespace Tnosc.Shop.Server.Module.Basket.Api.Endpoints.v2;
public class BasketEndpoint : EndpointBase
{
    public BasketEndpoint()
        : base("api/v{version:apiVersion}/baskets") => WithTags("Basket");

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new Asp.Versioning.ApiVersion(2))
            .ReportApiVersions()
            .Build();

        app.MapGet("checkpoint", () => Results.Ok("Basket API"))
        .Produces(200, typeof(string))
        .WithOpenApi(operation => new(operation)
        {
            Summary = "Check API Health",
            Description = "This endpoint is used to check if the Basket API is up and running."
        }).WithApiVersionSet(apiVersionSet);
    }
}
