# Use the official .NET image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FirmaXml.csproj", "./"]
RUN dotnet restore "FirmaXml.csproj"
COPY FirmaXml/ ./FirmaXml/
# WORKDIR "/src/FirmaXml"
RUN dotnet build "FirmaXml.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FirmaXml.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirmaXml.dll"]