#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/IotHub.API/IotHub.API.csproj", "src/IotHub.API/"]
COPY ["src/IotHub.DataTransferObjects/IotHub.DataTransferObjects.csproj", "src/IotHub.DataTransferObjects/"]
COPY ["src/IotHub.Common/IotHub.Common.csproj", "src/IotHub.Common/"]
COPY ["src/IotHub.Services/IotHub.Services.csproj", "src/IotHub.Services/"]
COPY ["src/IotHub.DomainModels/IotHub.DomainModels.csproj", "src/IotHub.DomainModels/"]
COPY ["src/IotHub.DB/IotHub.DB.csproj", "src/IotHub.DB/"]
COPY ["src/IotHub.Repositories/IotHub.Repositories.csproj", "src/IotHub.Repositories/"]
RUN dotnet restore "src/IotHub.API/IotHub.API.csproj"
COPY . .
WORKDIR "/src/src/IotHub.API"
RUN dotnet build "IotHub.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IotHub.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IotHub.API.dll"]
