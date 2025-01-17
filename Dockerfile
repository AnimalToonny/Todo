FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Todo/Todo.csproj", "Todo/"]
RUN dotnet restore "Todo/Todo.csproj"
COPY . .
WORKDIR "/src/Todo"
RUN dotnet build "Todo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.dll"]
