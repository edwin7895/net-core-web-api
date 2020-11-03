# Building Image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# Define parameter for secure pass certificate password on docker file
ARG certPassword
WORKDIR /app

# Copy internal projects
COPY ["webApi.sln","webApi.sln"]
COPY ["webApi.Api/webApi.Api.csproj","webApi.Api/"]
COPY ["webApi.Services/webApi.Services.csproj","webApi.Services/"]
COPY ["webApi.Data/webApi.Data.csproj","webApi.Data/"]
COPY ["webApi.Core/webApi.Core.csproj","webApi.Core/"]

# Restore packages
RUN dotnet restore

# Build and Publish solution
COPY . ./
RUN dotnet publish -c Release -o out
# Configure Self-signed Certificate
RUN dotnet dev-certs https -ep app/out/cert.pfx -p ${certPassword}

# Build runtime Image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

# Copy build from build-env image
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "webApi.Api.dll"]