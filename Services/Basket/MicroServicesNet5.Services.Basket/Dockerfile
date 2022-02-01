FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroServicesNet5.Shared/*.csproj Shared/MicroServicesNet5.Shared/
COPY Services/Basket/MicroServicesNet5.Services.Basket/*.csproj Services/Basket/MicroServicesNet5.Services.Basket/
RUN dotnet restore Services/Basket/MicroServicesNet5.Services.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/MicroServicesNet5.Services.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "MicroServicesNet5.Services.Basket.dll" ]
