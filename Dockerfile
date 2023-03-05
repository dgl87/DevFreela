FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /App
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DevFreela.API.csproj", "."]
RUN dotnet restore "./DevFreela.API/DevFreela.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DevFreela.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevFreela.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
