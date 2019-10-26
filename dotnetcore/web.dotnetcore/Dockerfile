 # Stage 1
 FROM microsoft/aspnetcore-build AS builder
 WORKDIR /publish

 #stage
 COPY *.csproj .
 RUN dotnet restore

 #stage 3
 COPY . .
 RUN dotnet publish --output ./out --configuration Release

#stage 4
FROM microsoft/aspnetcore
WORKDIR /app
COPY from --from=builder /publish/out .
ENTRYPOINT ['dotnet','web.dotnetcore.dll']



