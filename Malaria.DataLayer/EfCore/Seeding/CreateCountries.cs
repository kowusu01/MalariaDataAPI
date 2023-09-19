


using Common.Models.MalariaData;
using Common.Models;

using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using EfCoreLayer.WorldInfo;

namespace EfCoreLayer.Seeding
{
    public partial class Seeding
    {
        public static void CreateCountryListAsync(WorlInfoApiDbContext dbContext, string dbEnvironment, string dbEnvDescr)
        {

            if (!dbContext.EnvInfos.Any())
            {
                var dbEnvironmentInfo = new EnvInfo { Name = "LOCAL", Descr = "World facts api Database - InMemoryDB", DateCreated = DateTime.Now, IsActive = '1' };
                dbContext.EnvInfos.Add(dbEnvironmentInfo);
            }
            try
            {
                string countriesJson = File.ReadAllText("countrylist.json");
                if (countriesJson != null)
                {
                    var countryList = JsonConvert.DeserializeObject<Country[]>(countriesJson);

                    if (!dbContext.Countries.Any())
                    {
                        dbContext.Countries.AddRange(countryList);
                    }
                }

                string regionsJson = File.ReadAllText("who_regions.json");
                if (regionsJson != null)
                {
                    var regionsList = JsonConvert.DeserializeObject<WHORegion[]>(regionsJson);

                    if (!dbContext.WHORegions.Any())
                    {
                        dbContext.WHORegions.AddRange(regionsList);
                    }
                }

                dbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

    }

}


