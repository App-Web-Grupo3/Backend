FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["A Api/A Api.csproj", "A Api/"]
COPY ["C Data/C Data.csproj", "C Data/"]
COPY ["B Domain/B Domain.csproj", "B Domain/"]
COPY ["D Shared/D Shared.csproj", "D Shared/"]
RUN dotnet restore "A Api/A Api.csproj"
COPY . .
WORKDIR "/src/A Api"
RUN dotnet build "A Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A Api.dll"]
