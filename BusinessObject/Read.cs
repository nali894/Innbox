using System.Data;

namespace InnboxService
{
    public class Read
    {        
        public List<Service> GetServicesByRole(ServiceByRoleDTO serviceByRoleDTO)
        {
            List<Service> lstService = new List<Service>();

            Dictionary<string, dynamic> lstParameters = new Dictionary<string, dynamic>()
            {
                { "intServiceType",serviceByRoleDTO.intServiceType },
                { "strDatetime",serviceByRoleDTO.strDateTime }
            };

            DataTable dt = MySqlStartup.CallStoredProcedure_Read(lstParameters, "GetServicesByRole");

            if(dt.Rows.Count>0)
            {
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
            }

            return lstService; 
        }


        public User GetUserByUserName(string strUserName)
        {
            User oUser = new User();

            Dictionary<string, dynamic> lstParameters = new Dictionary<string, dynamic>()
            {
                { "strUserName",strUserName},
              
            };

            DataTable dt = MySqlStartup.CallStoredProcedure_Read(lstParameters, "GetUserByUserName");

            if (dt.Rows.Count > 0)
            {
                oUser = dt.AsEnumerable()
                     .Select(dataRow => new User
                     {
                         Code = dataRow.Field<string>("cod_usuario"),
                         IDNumType = dataRow.Field<string>("tipo_id"),
                         IdNumber = dataRow.Field<string>("num_id"),
                         Name = dataRow.Field<string>("nombres"),
                         LastName = dataRow.Field<string>("apellidos"),
                         CityCode = dataRow.Field<string>("cod_ciudad"),
                         Email = dataRow.Field<string>("email"),
                         CellPhoneNumber = dataRow.Field<string>("celular"),
                         RoleCode = dataRow.Field<string>("cod_rol"),
                         UserType= dataRow.Field<string>("cod_tipo_usua")
                     }).FirstOrDefault();  
            }

            return oUser;
        }

    }
}
