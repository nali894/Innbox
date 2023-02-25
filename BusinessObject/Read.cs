using MySql.Data.MySqlClient;
using System.Data;

namespace InnboxService
{
    public class Read
    {
        private static MySqlConnector.MySqlConnectionStringBuilder builder = Setting.GetStringBuilder();

        public List<Service> GetServicesByRole(ServiceByRoleDTO serviceByRoleDTO)
        {
            List<Service> lstService = new List<Service>();

            Dictionary<string, dynamic> lstParameters = new Dictionary<string, dynamic>()
            {
                { "intServiceType",serviceByRoleDTO.intServiceType },
                { "strDatetime",serviceByRoleDTO.strDateTime }
            };

            DataTable dt = MySqlStartup.CallStoredProcedure_Read(lstParameters, "GetServicesByRole");

            lstService = dt.AsEnumerable()
                      .Select(dataRow => new Service
                      {
                          Code = dataRow.Field<int>("cod_servicio"),
                          ServiceType = dataRow.Field<string>("descripcion"),
                          Status = dataRow.Field<string>("estado"),
                          Value = dataRow.Field<decimal>("valor"),
                          Address = dataRow.Field<string>("direccion"),
                          User = dataRow.Field<string>("usuario_asignado"),
                          CreateBy = dataRow.Field<string>("usuario_creacion"),
                          startDate = dataRow.Field<DateTime>("fecha_hora_inicio"),
                          EndDate = dataRow.Field<DateTime>("fecha_hora_fin"),
                          DatetimeCreation = dataRow.Field<DateTime>("fecha_creacion")
                      }).ToList();

            return lstService;
        }
    }
}
