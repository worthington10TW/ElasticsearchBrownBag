FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY DataLoader/DataLoader.csproj DataLoader/
RUN dotnet restore "DataLoader/DataLoader.csproj"
COPY . .
WORKDIR "/src/DataLoader"
RUN dotnet build "DataLoader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataLoader.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ELASTICSEARCH_HOSTS="http://localhost:9200"
LABEL org.opencontainers.image.source https://github.com/worthington10TW/ElasticsearchBrownBag
CMD ["sh", "-c", "dotnet DataLoader.dll $ELASTICSEARCH_HOSTS" ]