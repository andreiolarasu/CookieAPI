FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["./CookieAPI/CookieAPI.csproj", "CookieAPI/"]
RUN dotnet restore "./CookieAPI/CookieAPI.csproj"
COPY . .
WORKDIR "CookieAPI"
RUN dotnet build "CookieAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CookieAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD dotnet aspnetapp.dll