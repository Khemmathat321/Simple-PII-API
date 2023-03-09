FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PiApplication/PiApplication.csproj", "PiApplication/"]
RUN dotnet restore "PiApplication/PiApplication.csproj"
COPY . .
WORKDIR "/src/PiApplication"
RUN dotnet build "PiApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PiApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PiApplication.dll"]
