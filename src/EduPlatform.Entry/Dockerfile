#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EduPlatform.Entry/EduPlatform.Entry.csproj", "EduPlatform.Entry/"]
RUN dotnet restore "./EduPlatform.Entry/./EduPlatform.Entry.csproj"
COPY . .
WORKDIR "/src/EduPlatform.Entry"
RUN dotnet build "./EduPlatform.Entry.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EduPlatform.Entry.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME [ "/resources" ]
ENTRYPOINT ["dotnet", "EduPlatform.Entry.dll"]