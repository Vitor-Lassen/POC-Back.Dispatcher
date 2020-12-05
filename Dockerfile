#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Run.Simulados.Back.Dispatcher.Api/Run.Simulados.Back.Dispatcher.Api.csproj", "Run.Simulados.Back.Dispatcher.Api/"]
RUN dotnet restore "Run.Simulados.Back.Dispatcher.Api/Run.Simulados.Back.Dispatcher.Api.csproj"
COPY . .
WORKDIR "/src/Run.Simulados.Back.Dispatcher.Api"
RUN dotnet build "Run.Simulados.Back.Dispatcher.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Run.Simulados.Back.Dispatcher.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myuser
USER myuser
ENTRYPOINT ["dotnet", "Run.Simulados.Back.Dispatcher.Api.dll","-p","5555:4444"]
CMD ["-p","5555:4444"]
