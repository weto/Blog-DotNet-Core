FROM mcr.microsoft.com/dotnet/core/runtime-deps:2.2.7-alpine3.9
# ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
# ENTRYPOINT ["dotnet", "modelo_2"]
ENTRYPOINT ["dotnet"]
