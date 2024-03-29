#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Back.Dispatcher.Api/Back.Dispatcher.Api.csproj", "Back.Dispatcher.Api/"]
RUN dotnet restore "Back.Dispatcher.Api/Back.Dispatcher.Api.csproj"
COPY . .
WORKDIR "/src/Back.Dispatcher.Api"
RUN dotnet build "Back.Dispatcher.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Back.Dispatcher.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myuser
USER myuser
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Back.Dispatcher.Api.dll
