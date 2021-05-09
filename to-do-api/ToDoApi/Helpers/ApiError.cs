using System.Net;

namespace ToDoApi.Helpers
{
    public class ApiError
    {
        public ApiError(string message)
        {
            Message = message;
            StatusCode = 422;
            StatusDescription = HttpStatusCode.UnprocessableEntity.ToString();
        }

        public string Message { get; private set; }

        public int StatusCode { get; private set; }

        public string StatusDescription { get; private set; }
    }
}