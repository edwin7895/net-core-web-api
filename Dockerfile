# Building Image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy internal projects
COPY ["webapi.Api/webApi.Api.csproj","webapi.Api/"]
COPY ["webapi.Core/webApi.Core.csproj","webapi.Core/"]
COPY ["webapi.Services/webApi.Services.csproj","webapi.Services/"]

# Restore packages
RUN dotnet restore

# Build and Publish solution
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime Image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
ARG certPassword
# Configure Self-signed Certificate
RUN dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p ${certPassword}
# Copy build from build-env image
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "webApi.Api.dll"]