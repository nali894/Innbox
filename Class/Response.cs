namespace InnboxService
{
    public class Response
    {
        private int _intCode = 0;
        private dynamic _dynValue;
        private dynamic _strDescription="ok";

        public int Code
        {
            get { return this._intCode; }
            set { this._intCode = value; }
        }

        public string Description
        {
            get { return this._strDescription; }
            set { this._strDescription= value; }
        }
        public dynamic Values
        {
            get { return this._dynValue; }
            set { this._dynValue = value; }
        }
    }
       

}
