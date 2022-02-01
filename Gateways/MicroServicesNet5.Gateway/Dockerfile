FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Gateways/MicroServicesNet5.Gateway/*.csproj Gateways/MicroServicesNet5.Gateway/
RUN dotnet restore Gateways/MicroServicesNet5.Gateway/*.csproj
COPY . .
RUN dotnet publish Gateways/MicroServicesNet5.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "MicroServicesNet5.Gateway.dll" ]
