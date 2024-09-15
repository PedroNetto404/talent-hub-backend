FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TalentHub.Web/TalentHub.Web.csproj", "src/TalentHub.Web/"]
COPY ["src/TalentHub.Infra/TalentHub.Infra.csproj", "src/TalentHub.Infra/"]
COPY ["src/TalentHub.Infra/TalentHub.ApplicationCore.csproj", "src/TalentHub.ApplicationCore/"]
RUN dotnet restore "src/TalentHub.Web/TalentHub.Web.csproj"
COPY . .
WORKDIR "/src/src/TalentHub.Web"
RUN dotnet build "TalentHub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TalentHub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TalentHub.Web.dll"]
