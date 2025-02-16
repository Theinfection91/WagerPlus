# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WagerPlus.Bot/WagerPlus.Bot.csproj", "src/WagerPlus.Bot/"]
COPY ["src/WagerPlus.CommandLogic/WagerPlus.CommandLogic.csproj", "src/WagerPlus.CommandLogic/"]
COPY ["WagerPlus.Payments/WagerPlus.Payments.csproj", "WagerPlus.Payments/"]
COPY ["src/WagerPlus.Managers/WagerPlus.Managers.csproj", "src/WagerPlus.Managers/"]
COPY ["src/WagerPlus.Core/WagerPlus.Core.csproj", "src/WagerPlus.Core/"]
COPY ["src/WagerPlus.Data/WagerPlus.Data.csproj", "src/WagerPlus.Data/"]
RUN dotnet restore "./src/WagerPlus.Bot/WagerPlus.Bot.csproj"
COPY . .
WORKDIR "/src/src/WagerPlus.Bot"
RUN dotnet build "./WagerPlus.Bot.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WagerPlus.Bot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WagerPlus.Bot.dll"]