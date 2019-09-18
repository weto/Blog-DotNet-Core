FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

RUN mkdir app
COPY . ./app
WORKDIR /app 
RUN dotnet publish -o ./out -r linux-musl-x64 -c Release

FROM mcr.microsoft.com/dotnet/core/runtime-deps:2.2.7-alpine3.9
RUN mkdir /app
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 8080
ENTRYPOINT ["/app/modelo_2"]
