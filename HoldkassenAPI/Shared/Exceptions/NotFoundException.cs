using System.Net;

namespace HoldkassenAPI.Shared.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource) : base(resource, HttpStatusCode.NotFound)
        {
        }
    }
}