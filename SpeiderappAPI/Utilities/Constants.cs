namespace SpeiderappAPI.Utilities
{
    public class Constants
    {
        // Secrets directory
        public const string ENV_KEY__SECRETS_DIRECTORY = "SPEIDERAPP__SECRETS_DIRECTORY";
        public const string ENV_DEFAULT__SECRETS_DIRECTORY = "/run/secrets";
        public static readonly string[] DEV__SECRETS_DIRECTORY_RELATIVE = { ".docker", "secrets" };

        #region Database settings
        // Database default connection string, with placeholders to be inserted
        public const string DEFAULT_CONNECTION_STRING = "host={0};port={1};database={2};username={3};password={4}";
        // Database hostname
        public const string CONF_KEY__DATABASE_HOSTNAME = "SPEIDERAPP:DB_HOST";
        public const string CONF_DEFAULT__DATABASE_HOSTNAME = "localhost";
        // Database port
        public const string CONF_KEY__DATABASE_PORT = "SPEIDERAPP:DB_PORT";
        public const string CONF_DEFAULT__DATABASE_PORT = "5432";
        // Database database-name
        public const string CONF_KEY__DATABASE_DATABASE = "SPEIDERAPP:DB_DATABASE";
        public const string CONF_DEFAULT__DATABASE_DATABASE = "speiderapp";
        // Database username
        public const string CONF_KEY__DATABASE_USERNAME = "SPEIDERAPP:DB_USER";
        public const string CONF_DEFAULT__DATABASE_USERNAME = "speiderapp";
        // Database password
        public const string CONF_KEY__DATABASE_PASSWORD = "SPEIDERAPP:DB_PASS";
        public const string CONF_DEFAULT__DATABASE_PASSWORD = "";
        #endregion
    }
}
