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

using System.Reflection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Tnosc.Components.Abstractions.Module;
using Tnosc.Components.Infrastructure.Api;
using Tnosc.Components.Infrastructure.ApplicationService.Decorators;
using Tnosc.Components.Infrastructure.Logging;
using Tnosc.Components.Infrastructure.Module;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();
builder.WebHost.ConfigureModules();

IList<Assembly> _assemblies = ModuleLoader.LoadAssemblies(builder.Configuration, "Server.Module.");
IList<IModule> _modules = ModuleLoader.LoadModules(_assemblies);

builder.Services.AddOpenApi();
builder.Services.AddModules(builder.Configuration, _modules);
builder.Services.AddDefaultPipelineBehaviors();

Action<ResourceBuilder> appResourceBuilder =
            resource => resource
                .AddTelemetrySdk()
                .AddService(builder.Configuration.GetValue<string>("Otlp:ServiceName")!);

builder.Services.AddOpenTelemetry()
            .ConfigureResource(appResourceBuilder)
            .WithTracing(options => options
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter(options => options.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint")!))
            )
            .WithMetrics(options => options
                .AddRuntimeInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(options => options.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint")!)));

WebApplication app = builder.Build();

app.UseHsts();
app.UseModules(_modules);
app.UseOpenApi();

_assemblies.Clear();
_modules.Clear();

app.Run();
