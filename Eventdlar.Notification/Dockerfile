FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /app

COPY  *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=base /app .
ENTRYPOINT ["dotnet", "Eventdlar.Notification.dll"]