using System.Xml.Linq;

namespace InnboxService
{
    public class ServiceByRoleDTO
    {        
        private string _strRole = "";
    
        public string strRole
        {
            get { return _strRole; }   // get method
            set { _strRole = value; }  // set method


        }

        public string strDateTime { get; set; }
    }
}
