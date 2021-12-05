FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY publish .
ENTRYPOINT ["dotnet", "AvrRemote.Server.dll"]
