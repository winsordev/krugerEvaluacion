# syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY bin/Debug/netcoreapp3.1/publish/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "**krugerEvaluacion.dll**"]