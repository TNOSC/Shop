#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5080
EXPOSE 5081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Host/Tnosc.Shop.Server.Bootstrapper/Tnosc.Shop.Server.Bootstrapper.csproj", "src/Host/Tnosc.Shop.Server.Bootstrapper/"]
RUN dotnet restore "./src/Host/Tnosc.Shop.Server.Bootstrapper/Tnosc.Shop.Server.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/src/Host/Tnosc.Shop.Server.Bootstrapper"
RUN dotnet build "./Tnosc.Shop.Server.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tnosc.Shop.Server.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tnosc.Shop.Server.Bootstrapper.dll"]