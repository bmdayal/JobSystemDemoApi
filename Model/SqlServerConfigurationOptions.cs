namespace JobSystemDemoApi.Model
{
    public class SqlServerConfigurationOptions
    {
        public const string ServerConfig = "SqlServerConfig";

        /// <summary>
        /// When used from outside of Google VPC
        /// </summary>
        public string PublicServer { get; set; }

        /// <summary>
        /// Use When connecting from inside the same Google VPC, not implemented yet
        /// </summary>
        public string PrivateServer { get; set; } 

        /// <summary>
        /// Sql Server DB Name
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// SqlServer User Name required to connect to DB
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// SqlServer Password requried to connect to DB
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// When set to True, Account Processor will use SqlServer for Logging
        /// </summary>
        public bool Active { get; set; }
    }
}
