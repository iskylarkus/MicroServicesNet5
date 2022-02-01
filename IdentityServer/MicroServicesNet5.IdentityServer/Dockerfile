FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroServicesNet5.Shared/*.csproj Shared/MicroServicesNet5.Shared/
COPY IdentityServer/MicroServicesNet5.IdentityServer/*.csproj IdentityServer/MicroServicesNet5.IdentityServer/
RUN dotnet restore IdentityServer/MicroServicesNet5.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/MicroServicesNet5.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "MicroServicesNet5.IdentityServer.dll" ]
