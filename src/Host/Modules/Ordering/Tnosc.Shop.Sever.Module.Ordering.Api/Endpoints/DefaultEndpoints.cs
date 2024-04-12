/*
 MIT License
 
 Copyright (c) 2024 Ahmed HEDFI (ahmed.hedfi@gmail.com)
 
 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tnosc.Shop.Sever.Module.Ordering.Api.Endpoints;
internal static class DefaultEndpoints
{
    public static RouteGroupBuilder AddDefaultRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("checkpoint", () => Results.Ok("Order API"))
            .Produces(200, typeof(string))
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Check API Health",
                Description = "This endpoint is used to check if the Order API is up and running."
            });

        return group;
    }
}
