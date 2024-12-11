using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public abstract class ProductClientHubException : SystemException
    {
        public ProductClientHubException(string message) : base(message)
        {
            
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
