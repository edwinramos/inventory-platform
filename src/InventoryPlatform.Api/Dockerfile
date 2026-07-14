# -----------------------------
# Build stage
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build

WORKDIR /src

# Copy everything
COPY . .

# Restore ONLY the API project
RUN dotnet restore src/InventoryPlatform.Api/InventoryPlatform.Api.csproj

# Publish
RUN dotnet publish src/InventoryPlatform.Api/InventoryPlatform.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# -----------------------------
# Runtime stage
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "InventoryPlatform.Api.dll"]
