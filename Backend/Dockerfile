ARG DOTNET_VERSION=8.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

COPY . ./
RUN dotnet restore "CuraFlow.slnx"

RUN dotnet publish "src/CuraFlow.Api/CuraFlow.Api.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish ./

ENTRYPOINT ["dotnet", "CuraFlow.Api.dll"]
