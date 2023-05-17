
# 
#dotnet user-secrets init
#dotnet user-secrets set  "DataSourceType" "InMemory"
#dotnet user-secrets set  "DBInstance" "studentsdb"
dotnet run --launch-profile InMemoryDb StudentPrototype.API.csproj
