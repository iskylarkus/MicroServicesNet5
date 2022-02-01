FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroServicesNet5.Shared/*.csproj Shared/MicroServicesNet5.Shared/
COPY Services/Payment/MicroServicesNet5.Services.Payment/*.csproj Services/Payment/MicroServicesNet5.Services.Payment/
RUN dotnet restore Services/Payment/MicroServicesNet5.Services.Payment/*.csproj
COPY . .
RUN dotnet publish Services/Payment/MicroServicesNet5.Services.Payment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "MicroServicesNet5.Services.Payment.dll" ]
