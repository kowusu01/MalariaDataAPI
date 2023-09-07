using Microsoft.Net.Http.Headers;

namespace Common.Contants
{
    public class SecretsConstants
    {
        public static readonly string DataSourceType = "DataSourceType";
    }

    public class AwsConstants
    {
        /// <summary>
        /// the string representing the path for the aws secrets, a.k.a AwsSecretsId
        /// arn:aws:secretsmanager:{region}:{account_id}:secret:{secrets_path}
        ///  e.g. arn:aws:secretsmanager:us-east-1:11122233344:secret:myapp//dev-y2UGqa
        /// </summary>
        public static readonly string AwsSecretsPathTemplate = "arn:aws:secretsmanager:{0}:{1}:secret:{2}";

        /// <summary>
        /// the value of this must be passed via environment variable
        /// </summary>
        public static readonly string AwsParametersStorePath = "AwsParametersStorePath";

        public static readonly string AwsRegion = "AwsRegion";
        public static readonly string AwsAccountNumber = "AwsAccountId";

        public static readonly string AwsSecretsPathName= "AwsSecretsPathName";
        public static readonly string AwsSecretsId = "AwsSecretsId";

        public static readonly string AwsAccessKey = "AWS_ACCESS_KEY_ID";
        public static readonly string AwsAccessKeySecret = "AWS_SECRET_ACCESS_KEY";
    }

    public class CorsConfig
    {
        public static string CORS_ALLOWED_DOMAIN_KEY = "CORS_ALLOWED_DOMAINS";
        public static string CORS_ALLOWED_METHODS_KEY = "CORS_ALLOWED_METHODS";
        public static string CORS_POLICY_ALLOWS_KNOWN_ORIGINS = "CORS_POLICY_ALLOWS_KNOWN_ORIGINS";
    }
    
    public class DBConstants
    {
        /// <summary>
        /// the connection string template has the form:
        /// Host={0};Database={1};Username={2};Password={3}"
        /// </summary>
        public static readonly string ConnectionStringTemplate = "Host={0};Database={1};Username={2};Password={3}";
        
        /// <summary>
        /// InMemory or Server
        /// </summary>
        public static readonly string DBSource = "DataSourceType";

        public static readonly string DBServer = "DBServer";
        public static readonly string DBInstance = "DBInstance";
        public static readonly string DBUser = "DBUsername";
        public static readonly string DBPassword = "DBPassword";
    }

    public class DBSourceValues 
    {
        /// <summary>
        /// tells the app to user InMemory database
        /// </summary>
        public static readonly string InMemory = "InMemory";

        /// <summary>
        /// tells the app to use a real database server
        /// </summary>
        public static readonly string Server = "Server";

        /// <summary>
        /// cloud database like aws
        /// </summary>
        public static readonly string Cloud = "Cloud";

        public static string DefaultDbInstance = "malariadb_dev";
    }

    public class EnvironmentConstants
    {
        public static readonly string Label = "CurrentEnvironmentLabel";
        public static readonly string Name = "EnvName";
        public static readonly string Descr = "EnvDescr";

    }

    public enum FilterByColumnEnum
    {
        NoFiltering,
        Id,
        LoadId,
        RecordNumber,
        Descr,
        LoadTimestamp,
        FilePath,
        Completed,
        NumRecords,
        BadDataCount,
        WarningDataCount,
        IssueType
    };

    public enum OrderByColumnEnum
    {
        DefaultOrdering,
        Id,
        LoadId,
        RecordNumber,
        Country,
        Year,
        NumCases,
        NumDeaths,
        Region,
        LoadTimestamp,
        IssueType

    };

    public enum OrderBySchemeEnum
    {
        desc,
        asc
    }


}