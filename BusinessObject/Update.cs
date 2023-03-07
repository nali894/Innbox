namespace InnboxService
{
    public class Update
    {      
        public bool UpdateStatus(int intServiceID, string strStatus)
        {            
            Dictionary<string, dynamic> lstParameters = new Dictionary<string, dynamic>()
            {
                { "intServiceID",intServiceID },
                { "strStatus",strStatus}
            };

            return MySqlStartup.CallStoredProcedure_Update(lstParameters, "UptadeStatus");
           
        }
    }
}
