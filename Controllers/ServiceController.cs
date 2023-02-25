using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    }
}
