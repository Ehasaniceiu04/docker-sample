FROM microsoft/aspnetcore-build:2.0 AS build-env
MAINTAINER Ehasanul Hoque

WORKDIR /app

COPY MCashDemo.Web/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish /app/MCashDemo.Web/MCashDemo.Web.csproj -c Release -o out

# COPY config.environment/. /app/MCashDemo.Web/out/config.environment/ 

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/MCashDemo.Web/out .
ENTRYPOINT ["dotnet", "MCashDemo.Web.dll"]