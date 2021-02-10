#STAGE 1
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
LABEL AUTHOR="Soumik Paul"


#STAGE 2
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LicenseGeneratorApi.csproj", "./"]
RUN dotnet restore "LicenseGeneratorApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "LicenseGeneratorApi.csproj" -c Release -o /app/build

#STAGE 3
FROM build AS publish
RUN dotnet publish "LicenseGeneratorApi.csproj" -c Release -o /app/publish

#STAGE 4
FROM base AS final
#ENV ASPNETCORE_URLS http://+:5000 IS IMPORTANT SINCE BY DEFAULT DOCKER EXPOSES PORT 80 AND IF NOT DONE THEN SITE WILL NOT BE REACHABLE
ENV ASPNETCORE_URLS http://+:5000
ENV ASPNETCORE_ENVIRONMENT="Development"
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LicenseGeneratorApi.dll"]


