

using EfCoreLayer;
using Common.Models.MalariaData;
using System;


namespace EfCoreLayer.Seeding
{
    public partial class Seeding
    {
        public static void SeedMalariaDBAsync(AppDbContext dbContext, string dbEnvironment, string dbEnvDescr)
        {

            if (!dbContext.EnvInfos.Any())
            {
                var dbEnvironmentInfo  = new EnvInfo { Name="LOCAL", Descr = "Malaria Data Api Database - InMemoryDB", DateCreated = DateTime.Now, IsActive = '1' }; 
                dbContext.EnvInfos.Add(dbEnvironmentInfo);
            }

            if (!dbContext.LoadStats.Any())
            {
                dbContext.LoadStats.AddRange(Seeding.GetDataLoadStatSeedData());
            }

            if (!dbContext.CasesReportedCompletes.Any())
            {
                dbContext.CasesReportedCompletes.AddRange(GetGoodDataSeeding());
            }

            if (!dbContext.CasesReportedBads.Any())
            {
                dbContext.CasesReportedBads.AddRange(GetBadDataSeeding());
            }

            if (!dbContext.DataIssuesDetails.Any())
            {
               dbContext.DataIssuesDetails.AddRange(GetDataIssuesDetailsSeeding());
            }

            dbContext.SaveChanges();
        }

        private static List<Common.Models.MalariaData.LoadStat> GetDataLoadStatSeedData()
        {
            var stats = new List<LoadStat>()
                {
                   new LoadStat{ Id = 1,
                    Descr = "Data load 1",
                    FilePath = "data1.txt",
                    LoadStatus = "Success",
                    NumRecords = 12,
                    BadDataCount = 2,
                    WarningDataCount = 0,
                    LoadTimestamp = DateTime.Now.AddDays(-4)
                   }
                   
                   ,
                   new LoadStat{ Id = 2,
                    Descr = "Data load 2",
                    FilePath = "data2.txt",
                    LoadStatus = "Success",
                    NumRecords = 15,
                    BadDataCount = 2,                    
                    WarningDataCount = 1,
                    LoadTimestamp = DateTime.Now
                    
                   }
                   /*,
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
                   */
                };

            return stats;
        }

        private static List<CasesReportedComplete> GetGoodDataSeeding()
        {
            return new List<CasesReportedComplete>()
                {
                    new CasesReportedComplete{ Id=1,LoadId=1, RecordNumber=1, Country="Belize", Year=2017,NumCases=7,NumDeaths=0,Region="Americas"},                    
                    new CasesReportedComplete{ Id=2,LoadId=1, RecordNumber=2, Country="Benin", Year=2017,NumCases=1573163,NumDeaths=2182,Region="Africa"},
                    new CasesReportedComplete{ Id=3,LoadId=1, RecordNumber=3, Country="Bhutan", Year=2017,NumCases=240,NumDeaths=1,Region="South-East Asia"},
                    new CasesReportedComplete{ Id=4,LoadId=1, RecordNumber=4, Country="Bolivia (Plurinational State of)", Year=2017,NumCases=4572,NumDeaths=0,Region="Americas"},

                    new CasesReportedComplete{ Id=5,LoadId=1, RecordNumber=6, Country="Botswana", Year=2017,NumCases=1900,NumDeaths=17,Region="Africa"},
                    new CasesReportedComplete{ Id=6,LoadId=1, RecordNumber=7, Country="Brazil", Year=2017,NumCases=189503,NumDeaths=30,Region="Americas"},
                    new CasesReportedComplete{ Id=7,LoadId=1, RecordNumber=8, Country="Burkina Faso", Year=2017,NumCases=10225459,NumDeaths=4144,Region="Africa"},
                    new CasesReportedComplete{ Id=8,LoadId=1, RecordNumber=10, Country="Burundi", Year=2017,NumCases=7670177,NumDeaths=4414,Region="Africa"},
                    new CasesReportedComplete{ Id=9,LoadId=1, RecordNumber=11,  Country="Cabo Verde", Year=2017,NumCases=423,NumDeaths=2,Region="Africa"},
                    new CasesReportedComplete{ Id=10,LoadId=1, RecordNumber=12, Country="Cambodia", Year=2017,NumCases=36932,NumDeaths=1,Region="Western Pacific"},

                    new CasesReportedComplete{ Id=11,LoadId=2, RecordNumber=1, Country="Cameroon", Year=2017,NumCases=1191257,NumDeaths=3195,Region="Africa"},                    
                    new CasesReportedComplete{ Id=12,LoadId=2, RecordNumber=2, Country="Central African Republic", Year=2017,NumCases=383309,NumDeaths=3689,Region="Africa"},
                    new CasesReportedComplete{ Id=13,LoadId=2, RecordNumber=4, Country="Chad", Year=2017,NumCases=1962372,NumDeaths=2088,Region="Africa"},
                    new CasesReportedComplete{ Id=14,LoadId=2, RecordNumber=5, Country="China", Year=2017,NumCases=0,NumDeaths=7,Region="Western Pacific"},
                    new CasesReportedComplete{ Id=15,LoadId=2, RecordNumber=6, Country="Colombia",Year=2016,NumCases=82609,NumDeaths=36,Region="Americas"},

                    new CasesReportedComplete{ Id=16,LoadId=2, RecordNumber=8, Country="Comoros", Year=2017,NumCases=2274,NumDeaths=3,Region="Africa"},
                    new CasesReportedComplete{ Id=17,LoadId=2, RecordNumber=9, Country="Congo",Year=2016,NumCases=171847,NumDeaths=733,Region="Americas" },
                    new CasesReportedComplete{ Id=18,LoadId=2, RecordNumber=10, Country="Costa Rica", Year=2017,NumCases=12,NumDeaths=0,Region="Americas"},

                    //new CasesReportedComplete{ Id=4, LoadId=2, RecordNumber = 11, Country = "Argentina", Year=2017, NumCases=7000, NumDeaths=30000, Region = "Americas" }, // Warning data

                    new CasesReportedComplete{ Id=19,LoadId=2, RecordNumber=12, Country="Côte d''Ivoire", Year=2017,NumCases=3274683,NumDeaths=3222,Region="Africa"},
                    new CasesReportedComplete{ Id=20,LoadId=2, RecordNumber=13, Country="Democratic People''s Republic of Korea", Year=2017,NumCases=4575,NumDeaths=0,Region="Western Pacific"},

                    new CasesReportedComplete{ Id=21,LoadId=2, RecordNumber=15, Country="Afghanistan", Year=2017,NumCases=161778,NumDeaths=10,Region="Eastern Mediterranean"},
                    new CasesReportedComplete{ Id=22,LoadId=2, RecordNumber=16, Country="Algeria", Year=2017,NumCases=0,NumDeaths=0,Region="Africa"}

                };
        }

        private static List<Common.Models.MalariaData.CasesReportedBad> GetBadDataSeeding()
        {
            return new List<CasesReportedBad>() {

                  new CasesReportedBad { Id=1, LoadId=1, RecordNumber=5, Country="Armenia", Year="2017", NumCases="",NumDeaths="5000.0",Region="Europe" }
                , new CasesReportedBad{ Id=2, LoadId=1, RecordNumber=9, Country="Angola", Year="2017",NumCases="3874892.0",NumDeaths="",Region="Africa" }

                , new CasesReportedBad{ Id=3, LoadId=2, RecordNumber = 7, Country="Azerbaijan", Year="2017",NumCases="0.0", NumDeaths="", Region="Europe" }
                , new CasesReportedBad{ Id=4, LoadId=2, RecordNumber = 11, Country = "Argentina", Year="2017", NumCases="7000.0", NumDeaths="30000.0", Region = "Americas" } // Warning data
                , new CasesReportedBad{ Id=5, LoadId=2, RecordNumber = 14, Country = "Bangladesh", Year = "2017", NumCases = "4893.0", NumDeaths = "", Region = "South-East Asia" }
            };
        }

        private static List<Common.Models.MalariaData.DataIssuesDetail> GetDataIssuesDetailsSeeding()
        {
            return new List<DataIssuesDetail>()
            {
                new DataIssuesDetail{ Id=1, LoadId=1, RecordNumber=5, ColumnName="NumCases", IssueType="Error", Issue="Null or empty"},
                new DataIssuesDetail{ Id=2, LoadId=1, RecordNumber=9, ColumnName="NumDeaths", IssueType="Error",Issue="Null or empty"},

                new DataIssuesDetail{ Id=3, LoadId=2, RecordNumber=7, ColumnName="NumDeaths", IssueType="Error", Issue="Null or empty"},
                new DataIssuesDetail{ Id=4, LoadId=2, RecordNumber=11, ColumnName="NumDeaths", IssueType="Warning", Issue="inconsistency between NumCases and NumDeaths"},
                new DataIssuesDetail{ Id=5, LoadId=2, RecordNumber=14, ColumnName="NumDeaths", IssueType="Error", Issue="Null or empty"}
            };
        }
    }

}


