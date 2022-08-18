#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/IotHub.Agent/IotHub.Agent.csproj", "src/IotHub.Agent/"]
COPY ["src/IotHub.Repositories/IotHub.Repositories.csproj", "src/IotHub.Repositories/"]
COPY ["src/IotHub.DB/IotHub.DB.csproj", "src/IotHub.DB/"]
COPY ["src/IotHub.DomainModels/IotHub.DomainModels.csproj", "src/IotHub.DomainModels/"]
COPY ["src/IotHub.Common/IotHub.Common.csproj", "src/IotHub.Common/"]
COPY ["src/IotHub.Services/IotHub.Services.csproj", "src/IotHub.Services/"]
COPY ["src/IotHub.DataTransferObjects/IotHub.DataTransferObjects.csproj", "src/IotHub.DataTransferObjects/"]
RUN dotnet restore "src/IotHub.Agent/IotHub.Agent.csproj"
COPY . .
WORKDIR "/src/src/IotHub.Agent"
RUN dotnet build "IotHub.Agent.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IotHub.Agent.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IotHub.Agent.dll"]
