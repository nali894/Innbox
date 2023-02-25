using System.Xml.Linq;

namespace InnboxService
{
    public class ServiceByRoleDTO
    {
        private int _intServiceType=1;
        private string _strRole = "";
        public int intServiceType 
        {
            get { return _intServiceType; }   // get method
            set { _intServiceType = value; }  // set method


        }

        public string strRole
        {
            get { return _strRole; }   // get method
            set { _strRole = value; }  // set method


        }

        public string strDateTime { get; set; }      
    }
}
