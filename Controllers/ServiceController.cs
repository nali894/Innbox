using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InnboxService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private Response _oResponse = new Response();    


        [HttpPost]
        [Route("GetServicesByRole")]
        public Response GetServicesByRole(ServiceByRoleDTO serviceByRoleDTO)
        {
            try
            {
                DateTime dtime = DateTime.Parse(serviceByRoleDTO.strDateTime);
                serviceByRoleDTO.strDateTime = dtime.ToString("yyyy-MM-dd HH:mm:ss");
                Read read = new Read();
                List<Service> lstService = read.GetServicesByRole(serviceByRoleDTO);
                _oResponse.Values = lstService;
            }
            catch(Exception ex)
            {
                _oResponse.Code = 701;
                _oResponse.Description = $"Error:{ex.Message}";
            }
            

            return _oResponse;
        }

        [HttpPost]
        [Route("UpdateStatus")]
        public Response UpdateStatus(ServiceStatus oServiceStatus)
        {
            try
            {
                Update oUpdate = new Update();
                _oResponse.Values = oUpdate.UpdateStatus(oServiceStatus.intServiceID, oServiceStatus.strStatus);
            }
            catch (Exception ex)
            {
                _oResponse.Code = 701;
                _oResponse.Description = $"Error:{ex.Message}";
            }

            return _oResponse;
        }

        [HttpPost]
        [Route("GetUserByUserName")]
        public Response GetUserByUserName(UserName oUserName)
        {
            try
            {
                Read oRead = new Read();
                User oUser = oRead.GetUserByUserName(oUserName.strUserName);
                _oResponse.Values = oUser;
            }
            catch (Exception ex)
            {
                _oResponse.Code = 701;
                _oResponse.Description = $"Error:{ex.Message}";
            }
            return _oResponse;
        }

    }
}
