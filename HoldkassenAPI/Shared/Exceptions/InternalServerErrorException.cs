using System.Net;

namespace HoldkassenAPI.Shared.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException() : base(Resources.Exceptions.InternalServerError, HttpStatusCode.InternalServerError)
        {
            
        }
    }
}