FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY Api/bin/Release/netcoreapp3.1/publish/ App/src/
WORKDIR /App/src/
ENTRYPOINT ["dotnet", "Api.dll"]