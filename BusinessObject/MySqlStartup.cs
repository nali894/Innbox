using MySql.Data.MySqlClient;
using System.Data;

namespace InnboxService
{
    public static class MySqlStartup
    {
        private static MySqlConnector.MySqlConnectionStringBuilder builder = Setting.GetStringBuilder();


        public static DataTable CallStoredProcedure_Read(Dictionary<string, dynamic> lstParameters, string strStoredProcedure)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(builder.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(strStoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    foreach (KeyValuePair<string, dynamic> parameter in lstParameters)
                    {
                        cmd.Parameters.AddWithValue($"{parameter.Key}", $"{parameter.Value}");
                    }

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {                        
                        sda.Fill(dt);                      
                    }
                }
            }

            return dt;
        }




    }
}