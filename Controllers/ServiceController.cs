using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InnboxService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private Response _oResponse = new Response();


        [HttpPost]
        [Route("AcceptService")]
        public Response AcceptService(ServiceUser oServiceUser)
        {
            try
            {
                Update oUpdate = new Update();
                bool bUpdateUser = oUpdate.UpdateService_User(oServiceUser.intServiceID, oServiceUser.strUserCode);

                if (bUpdateUser)
                {
                    bool bUpdateStatus = oUpdate.UpdateStatus(oServiceUser.intServiceID, "2");

                    if (bUpdateStatus)
                    {
                        Read oRead = new Read();
                        _oResponse.Values =$"Estado:{oRead.GetServiceById(oServiceUser.intServiceID).Status}";
                    }
                    else
                    {
                        _oResponse.Code = 802;
                        _oResponse.Description = $"Error:No se actualizó el estado del servicio";
                    }
                }
                else
                {
                    _oResponse.Code = 802;
                    _oResponse.Description = $"Error:No se asignó el usuario";
                }
            }
            catch (Exception ex)
            {
                _oResponse.Code = 701;
                _oResponse.Description = $"Error:{ex.Message}";
            }

            return _oResponse;
        }


        [HttpGet]
        [Route("GetAllRoles")]
        public Response GetAllRoles()
        {
            try
            {              
                Read read = new Read();
                List<RoleService> lstService = read.GetAllRoles();
                _oResponse.Values = lstService;
            }
            catch (Exception ex)
            {
                _oResponse.Code = 701;
                _oResponse.Description = $"Error:{ex.Message}";
            }


            return _oResponse;
        }

        [HttpGet]
        [Route("GetAllServices")]
        public Response GetAllServices()
        {
            try
            {               
                Read read = new Read();
                List<Service> lstService = read.GetAllServices();
                _oResponse.Values = lstService;
            }
            catch (Exception ex)
            {
                _oResponse.Code = 701;
                _oResponse.Description = $"Error:{ex.Message}";
            }


            return _oResponse;
        }




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
