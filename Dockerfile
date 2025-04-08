# Используем официальный образ .NET SDK
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChatExampleEvent/ChatExampleEvent.csproj", "ChatExampleEvent/"]
RUN dotnet restore "ChatExampleEvent/ChatExampleEvent.csproj"
COPY . .
WORKDIR "/src/ChatExampleEvent"
RUN dotnet build "ChatExampleEvent.csproj" -c Release -o /app/build
RUN dotnet publish "ChatExampleEvent.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ChatExampleEvent.dll"]
