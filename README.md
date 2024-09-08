# Shop Reference Application

A reference .NET application implementing an eCommerce web site using a **modular architecture**.

![eShop Reference Application architecture diagram](./docs/src/images/eshop_architecture.png)

## Goals
 By adopting a modular approach, we aim to create a flexible and scalable application that can easily adapt to evolving requirements. 
 
 Additionally, this project serves as a platform for learning and implementing advanced concepts in software development such as CQRS, DDD, Clean architecture and so on.



## Getting Started

### Prerequisites

- Install the latest [.NET 8 SDK](https://github.com/dotnet/installer#installers-and-binaries)
- (Windows only) Install Visual Studio. [Visual Studio 2022 version 17.10 Preview](https://visualstudio.microsoft.com/vs/preview/).
- Install & start Docker Desktop:  https://docs.docker.com/engine/install/
- Clone the Shop repository: https://github.com/TNOSC/shop

### Running Dependencies

1. Navigate to the `infra` folder where the Docker Compose configuration for dependencies is located:
```powershell
   cd infra
```
2. Run Docker Compose to start the required dependencies (e.g., databases, message brokers, etc.):
```powershell
docker-compose up -d
```

The Docker Compose setup will run the following services:

| **Service**   | **Ports**                   | **Description**                                                                                   |
|---------------|-----------------------------|---------------------------------------------------------------------------------------------------|
| **blackbox**  | `9115:9115`                 | Prometheus Blackbox Exporter for probing endpoints.                                                |
| **prometheus**| `9090:9090`                 | Prometheus monitoring system and time series database.                                             |
| **tempo**     | `3200:3200`, `4007:4317`    | Grafana Tempo for tracing. Exposes OTLP gRPC and tracing services.                                 |
| **loki**      | `3100:3100`                 | Grafana Loki for log aggregation and querying.                                                     |
| **grafana**   | `3000:3000`                 | Grafana for data visualization dashboards.                                                         |
| **otel-collector**| `8888:8888`, `8889:8889`, `4317:4317`, `9200:55679`, `13133:13133` | OpenTelemetry Collector for processing telemetry data from various sources.                         |
| **rabbitmq**  | `5672:5672`, `15672:15672`  | RabbitMQ message broker with management UI.                                                        |
| **postgres**  | `5432:5432`                 | PostgreSQL database for storing application data.                                                  |
| **pgadmin**   | `9080:80`                   | pgAdmin for managing PostgreSQL databases.                                                         |


### Running the solution

* (Windows only) Run the application from Visual Studio:
 - Open the `Tnosc.Shop.sln` file in Visual Studio
 - Ensure that `Tnosc.Shop.Server.Bootstrapper.csproj`, `Tnosc.Shop.BFF.csproj` and `Tnosc.Shop.Client.Host.Web.csproj` are your startup projects
	
	![startup projects](./docs/src/images/startup-project.PNG)
 - Hit Ctrl-F5 to launch the application 

* Or run the application from your terminal using docker:
```powershell
dotnet dev-certs https -ep "$env:APPDATA\ASP.NET\Https\tnoscshop.pfx" -p tnosc --trust
docker-compose up -d
```


The following table lists all the running services along with their exposed ports and a brief description:

### Shared Libraries

This project uses shared libraries encapsulated as Nuget packages https://www.nuget.org/profiles/TNOSC to promote code reusability and maintainability.

For more information about these shared libraries, please check this link https://tnosc.gitbook.io/tnosc.

## Documentation

The documentation for this project follows the [arc42 template](https://arc42.org/overview), which is a standardized approach for documenting software and system architecture. 

The PDF output of the documentation is located [here](./docs/build/pdf/arc42/arc42.pdf).

## Technologies & Libraries
- OpenTelemetry
- Microsoft Fluent UI Blazor components
- Minimal APIs
- Swagger & Swagger UI
- MediatR
- FluentValidation
- Entity Framework Core
- xUnit
- ArchUnitNET
- ...

## License
This project is licensed with the [MIT license](./LICENSE.txt) .

## Contributing

For more information on contributing to this repo, please read [the contribution documentation](./CONTRIBUTING.md) and [the Code of Conduct](CODE-OF-CONDUCT.md).

## Inspirations and Recommendations

 Below you'll find a list of repositories and YouTube channels that were instrumental in developing this application. These resources provided valuable insights, tutorials, and code examples that contributed to the creation of our project.

### Repositories
- [modular-framework](https://github.com/devmentors/modular-framework) : Set of shared abstractions & components for building the modular monolith.
- [DomainDrivenDesignUniversity](https://github.com/dr-marek-jaskula/DomainDrivenDesignUniversity) : This project was made for tutorial purpose - to clearly present the domain driven design concept.
- [eShop](https://github.com/dotnet/eShop) : A reference .NET application implementing an eCommerce site.

### YouTube Channels
- [Devmentors](https://www.youtube.com/@DevMentorsEN)
- [Nick Chapsas](https://www.youtube.com/@nickchapsas)
- [Milan Jovanovic](https://www.youtube.com/@MilanJovanovicTech)
