using System.Net;

namespace HoldkassenAPI.Shared.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string resource) : base(resource, HttpStatusCode.BadRequest)
        {
        }
    }
}