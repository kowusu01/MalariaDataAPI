

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
                var stats = new List<LoadStat>() 
                {
                   new LoadStat{ Id = 1,
                    Descr = "Data load 1",
                    Completed = true,
                    NumRecords = 10,
                    BadDataCount = 0,
                    FilePath = "data1.txt",
                    LoadTimestamp = DateTime.Now,
                    WarningDataCount = 0
                   },
                   new LoadStat{ Id = 2,
                    Descr = "Data load 2",
                    Completed = true,
                    NumRecords = 20,
                    BadDataCount = 0,
                    FilePath = "data2.txt",
                    LoadTimestamp = DateTime.Now,
                    WarningDataCount = 0
                   },
                   new LoadStat{ Id = 3,
                    Descr = "Data load 3",
                    Completed = true,
                    NumRecords = 30,
                    BadDataCount = 0,
                    FilePath = "data3.txt",
                    LoadTimestamp = DateTime.Now.AddDays(-3),
                    WarningDataCount = 0
                   },
                   new LoadStat{ Id = 4,
                    Descr = "Data load 4",
                    Completed = true,
                    NumRecords = 40,
                    BadDataCount = 0,
                    FilePath = "data4.txt",
                    LoadTimestamp = DateTime.Now.AddDays(-5),
                    WarningDataCount = 0 
                   }
                   ,
                   new LoadStat{ Id = 5,
                    Descr = "Data load 5",
                    Completed = true,
                    NumRecords = 50,
                    BadDataCount = 0,
                    FilePath = "data5.txt",
                    LoadTimestamp = DateTime.Now.AddDays(-5),
                    WarningDataCount = 0
                   }
                };

                var stat = new LoadStat
                {
                    Id = 5,
                    Descr = "Data load 5",
                    Completed = true,
                    NumRecords = 50,
                    BadDataCount = 0,
                    FilePath = "data5.txt",
                    LoadTimestamp = DateTime.Now.AddDays(-5),
                    WarningDataCount = 0
                };


                var stat1 = new LoadStat
                {
                    Id = 6,
                    Descr = "Data load 5",
                    Completed = true,
                    NumRecords = 60,
                    BadDataCount = 0,
                    FilePath = "data5.txt",
                    LoadTimestamp = DateTime.Now,
                    WarningDataCount = 0
                };
                //dbContext.LoadStats.Add(stat);
                //dbContext.LoadStats.Add(stat1);

                dbContext.LoadStats.AddRange(stats);

                //var envInfo = new DBEnvironmentInfo() { ID = dbEnvironment, Descr = dbEnvDescr };
                //dbContext.DBEnvironmentInfo.Add(envInfo);
                dbContext.SaveChanges();
            }
        }

        }
    }
