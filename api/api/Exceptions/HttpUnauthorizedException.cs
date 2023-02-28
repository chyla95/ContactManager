using System.Net;

namespace api.Exceptions
{
    public class HttpUnauthorizedException : HttpException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;

        public HttpUnauthorizedException(string message = "Unauthorized!") : base(message) { }
    }
}
