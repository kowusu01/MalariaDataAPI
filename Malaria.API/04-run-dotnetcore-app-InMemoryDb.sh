
# 
#dotnet user-secrets init
#dotnet user-secrets set  "DataSourceType" "InMemory"
#dotnet user-secrets set  "DBInstance" "studentsdb"
dotnet run --launch-profile InMemoryDb StudentPrototype.API.csproj

# docker execute  - InMemory DB
#  docker run -ti -p 8081:80 -e DataSourceType="InMemory" -e DBInstance="malariadb_dev" -e ASPNETCORE_ENVIRONMENT="Development" --name=api.malaria.dev  malaria-api

# docker execute  - postgres DB
docker run -ti -p 8081:80 
-e DBInstance="malariadb_dev" 
-e DataSourceType="Server"
-e DBServer="localhost"
-e DBInstance="malariadb_dev"
-  DBUsername="postgres"
-e DBPassword="postgrespw"
-e ASPNETCORE_ENVIRONMENT="Development" --name=api.malaria.dev  malaria-api

# https://localhost:7096/swagger/index.html
https://localhost:5000/swagger/index.html