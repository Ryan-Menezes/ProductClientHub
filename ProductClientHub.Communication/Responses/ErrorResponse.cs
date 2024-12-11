namespace ProductClientHub.Communication.Responses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; private set; }

        public ErrorResponse(string message)
        {
            // Errors = new List<string>() { message };
            Errors = [message];
        }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }
    }
}
