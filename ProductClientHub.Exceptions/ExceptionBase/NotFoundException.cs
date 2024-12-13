using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class NotFoundException : SystemException
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public List<string> GetErrors() => [Message];

        public HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
