

using EfCoreLayer;
using Common.Models.MalariaData;


namespace EfCoreLayer.Seeding
{
    public partial class Seeding
    {
        public static void SeedMalariaDBAsync(AppDbContext dbContext, string dbEnvironment, string dbEnvDescr)
        {
            if (!dbContext.LoadStats.Any())
            {
                var stat = new LoadStat()
                {
                    Id = 1,
                    Descr = "Test",
                    Completed = true,
                    NumRecords = 1,
                    BadDataCount = 0,
                    FilePath = "data.txt",
                    LoadTimestamp = DateTime.Now,
                    WarningDataCount = 0

                };

                dbContext.LoadStats.Add(stat);

                //var envInfo = new DBEnvironmentInfo() { ID = dbEnvironment, Descr = dbEnvDescr };
                //dbContext.DBEnvironmentInfo.Add(envInfo);
                dbContext.SaveChanges();
            }
        }

        }
    }
