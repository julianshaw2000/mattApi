FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["api.csproj", "./"]
RUN dotnet restore "./api.csproj"

COPY . .

#WORKDIR "/src/."
#RUN dotnet build "api.csproj" -c Release -o /app/build
#FROM build AS publish

RUN dotnet publish "api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]

# docker run -d -p 80:80 92c30433e989
# docker build -t dockaws-api .
# docker start loving_driscoll
# docker tag 92c3 julianshaw2000/dockaws-app
# docker push julianshaw2000/dockaws-app
# https://www.youtube.com/watch?v=wQSuZFd01tY
