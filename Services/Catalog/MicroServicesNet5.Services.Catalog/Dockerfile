FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroServicesNet5.Shared/*.csproj Shared/MicroServicesNet5.Shared/
COPY Services/Catalog/MicroServicesNet5.Services.Catalog/*.csproj Services/Catalog/MicroServicesNet5.Services.Catalog/
RUN dotnet restore Services/Catalog/MicroServicesNet5.Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/MicroServicesNet5.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "MicroServicesNet5.Services.Catalog.dll" ]
