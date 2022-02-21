namespace SpeiderappAPI.Utilities
{
    public class Constants
    {
        // Secrets directory
        public const string EnvKeySecretsDirectory = "SPEIDERAPP__SECRETS_DIRECTORY";
        public const string EnvDefaultSecretsDirectory = "/run/secrets";
        public static readonly string[] DevSecretsDirectoryRelative = { ".docker", "secrets" };

        #region Database settings
        // Database default connection string, with placeholders to be inserted
        public const string DefaultConnectionString = "host={0};port={1};database={2};username={3};password={4}";
        // Database hostname
        public const string ConfKeyDatabaseHostname = "SPEIDERAPP:DB_HOST";
        public const string ConfDefaultDatabaseHostname = "localhost";
        // Database port
        public const string ConfKeyDatabasePort = "SPEIDERAPP:DB_PORT";
        public const string ConfDefaultDatabasePort = "5432";
        // Database database-name
        public const string ConfKeyDatabaseDatabase = "SPEIDERAPP:DB_DATABASE";
        public const string ConfDefaultDatabaseDatabase = "speiderapp";
        // Database username
        public const string ConfKeyDatabaseUsername = "SPEIDERAPP:DB_USER";
        public const string ConfDefaultDatabaseUsername = "speiderapp";
        // Database password
        public const string ConfKeyDatabasePassword = "SPEIDERAPP:DB_PASS";
        public const string ConfDefaultDatabasePassword = "";
        #endregion
    }
}
