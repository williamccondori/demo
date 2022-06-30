FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FpcMovil.ApiGateway/FpcMovil.ApiGateway.csproj", "FpcMovil.ApiGateway/"]
RUN dotnet restore "FpcMovil.ApiGateway/FpcMovil.ApiGateway.csproj"
COPY . .
WORKDIR "/src/FpcMovil.ApiGateway"
RUN dotnet build "FpcMovil.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FpcMovil.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV TZ="America/Lima"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FpcMovil.ApiGateway.dll"]
