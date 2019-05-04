FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MovilVentas-Modulo1.Domain/MovilVentas-Modulo1.Domain.csproj", "MovilVentas-Modulo1.Domain/"]
COPY ["MovilVentas-Modulo1.Api/MovilVentas-Modulo1.Api.csproj", "MovilVentas-Modulo1.Api/"]

RUN dotnet restore "MovilVentas-Modulo1.Api/MovilVentas-Modulo1.Api.csproj"
COPY . .
WORKDIR "/src/MovilVentas-Modulo1.Api"
RUN dotnet build "MovilVentas-Modulo1.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MovilVentas-Modulo1.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MovilVentas-Modulo1.Api.dll"]
