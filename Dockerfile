FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AirCode.csproj", "./"]
RUN dotnet restore "AirCode.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "AirCode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirCode.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ADD course.yaml .
ENTRYPOINT ["dotnet", "AirCode.dll"]
