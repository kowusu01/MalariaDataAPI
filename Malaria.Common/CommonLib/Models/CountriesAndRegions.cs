

namespace Common.Models.WorldInfo
{
    public partial class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string OfficialName { get; set; }
        public string? WHORegion { get; set; }
        public string? WHORegionName { get; set; }
        public string? WHORegionCode { get; set; }
        public string IsWHOCountry { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public string ISONum { get; set; }

    }

    public class WHORegion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }

    }

    

}