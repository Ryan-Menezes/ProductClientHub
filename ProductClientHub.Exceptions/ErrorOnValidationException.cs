using ProductClientHub.Exceptions.ExceptionBase;
using System.Net;

namespace ProductClientHub.Exceptions
{
    public class ErrorOnValidationException : ProductClientHubException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errors) : base(string.Empty)
        {
            _errors = errors;
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}
