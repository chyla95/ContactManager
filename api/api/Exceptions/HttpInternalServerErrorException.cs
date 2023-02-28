using System.Net;

namespace api.Exceptions
{
    public class HttpInternalServerErrorException : HttpException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;

        public HttpInternalServerErrorException(string message = "Internal Server Error!") : base(message) { }
    }
}
