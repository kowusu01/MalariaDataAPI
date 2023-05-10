﻿namespace Common.Contants
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

        public static string DefaultDbInstance = "studentsdb";
    }

    public class CurrentEnvironment
    {
        public static readonly string Label = "CurrentEnvironmentLabel";
    }

    public enum FilterByColumnEnum
    {
        no_filter,
        id,
        descr,
        load_timestamp,
        file_path,
        completed,
        num_records,
        bad_data_count,
        warning_data_count
    };

    public enum OrderByColumnEnum
    {
        default_ordering,
        id,
        load_id,
        record_number,
        country,
        year,
        num_cases,
        num_deaths,
        region,
        load_timestamp
    };

    public enum OrderBySchemeEnum
    {
        desc,
        asc
    }


}