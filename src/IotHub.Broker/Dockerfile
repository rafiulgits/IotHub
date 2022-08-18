#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 1883
EXPOSE 1884

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/IotHub.Broker/IotHub.Broker.csproj", "src/IotHub.Broker/"]
COPY ["src/IotHub.Services/IotHub.Services.csproj", "src/IotHub.Services/"]
COPY ["src/IotHub.DataTransferObjects/IotHub.DataTransferObjects.csproj", "src/IotHub.DataTransferObjects/"]
COPY ["src/IotHub.Common/IotHub.Common.csproj", "src/IotHub.Common/"]
COPY ["src/IotHub.DomainModels/IotHub.DomainModels.csproj", "src/IotHub.DomainModels/"]
COPY ["src/IotHub.DB/IotHub.DB.csproj", "src/IotHub.DB/"]
COPY ["src/IotHub.Repositories/IotHub.Repositories.csproj", "src/IotHub.Repositories/"]
RUN dotnet restore "src/IotHub.Broker/IotHub.Broker.csproj"
COPY . .
WORKDIR "/src/src/IotHub.Broker"
RUN dotnet build "IotHub.Broker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IotHub.Broker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IotHub.Broker.dll"]
