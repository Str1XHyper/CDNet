FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CodeByT.CDNet.Controller/CodeByT.CDNet.Controller.csproj", "CodeByT.CDNet.Controller/"]
COPY ["CodeByT.CDNet.DataAccess/CodeByT.CDNet.DataAccess.csproj", "CodeByT.CDNet.DataAccess/"]
COPY ["CodeByT.CDNet.DependencyInjection/CodeByT.CDNet.DependencyInjection.csproj", "CodeByT.CDNet.DependencyInjection/"]
COPY ["CodeByT.CDNet.Interfaces/CodeByT.CDNet.Interfaces.csproj", "CodeByT.CDNet.Interfaces/"]
COPY ["CodeByT.CDNet.Models/CodeByT.CDNet.Models.csproj", "CodeByT.CDNet.Models/"]
COPY ["CodeByT.CDNet.Repositories/CodeByT.CDNet.Repositories.csproj", "CodeByT.CDNet.Repositories/"]
COPY ["CodeByT.CDNet.Services/CodeByT.CDNet.Services.csproj", "CodeByT.CDNet.Services/"]

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
