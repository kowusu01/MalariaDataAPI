
using Common.Contants;
namespace Common.QueryParameters
{
    public class DataQueryParameters
    {
        public DataQueryParameters()
        {
            QueryComparisonNumeric = new List<(DataFiltersNumeric op, MalariaDataColumns col, int value)>();
            QueryComparisonString = new List<(DataFiltersString op, MalariaDataColumns col, string value)>();
            QueryOp = (SingleValuesOperations.none, MalariaDataColumns.none);

        }

        public List<(DataFiltersNumeric op, MalariaDataColumns col, int value)> QueryComparisonNumeric  { get; set; }
        public List<(DataFiltersString op, MalariaDataColumns col, string value)> QueryComparisonString { get; set; }

        public (SingleValuesOperations op, MalariaDataColumns col) QueryOp { get; set; }
        
    }
    
    // sum/num_cases
    // avg/num_cases
    // count/num_cases
    public enum SingleValuesOperations
    {
        count, sum, avg,
        min, max,
        none
    }

    // sum/num_cases
    // avg/num_cases
    // count/num_cases
    public enum OthersOperations
    {
        none,
        count, sum, avg,
        min, max,
        range,
        groupBy
    }

    // num_cases/greater/1
    public enum DataFiltersNumeric
    {
        none,
        eq, neq,
        lt, gt,
        lteq, gteq
    }
    public enum DataFiltersString
    {
        none,
        eq, neq,
        lt, gt,
        lteq, gteq
    }
    public enum MalariaDataColumns
    {
        country,
        region,
        year,
        numCases,
        numDeaths,
        loadId,
        none
    }


}