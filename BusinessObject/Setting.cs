using MySqlConnector;

namespace InnboxService
{
    public static class Setting
    {
        public static MySqlConnectionStringBuilder GetStringBuilder()
        {

            IConfigurationSection config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MySqlBuilder");
            MySqlConnectionStringBuilder? builder = new MySqlConnectionStringBuilder
            {
                Server = config["HostName"],
                Database = config["Database"],
                UserID = config["UserName"],
                Password = config["Password"],
                SslMode = MySqlSslMode.Required,
            };

            return builder;
        }
    }
}
