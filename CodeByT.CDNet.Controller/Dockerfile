FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CodeByT.CDNet.Controller/CodeByT.CDNet.Controller.csproj", "CodeByT.CDNet.Controller/"]
RUN dotnet restore "CodeByT.CDNet.Controller/CodeByT.CDNet.Controller.csproj"
COPY . .
WORKDIR "/src/CodeByT.CDNet.Controller"
RUN dotnet build "CodeByT.CDNet.Controller.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeByT.CDNet.Controller.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeByT.CDNet.Controller.dll"]
