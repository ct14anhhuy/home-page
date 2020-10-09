using System;
using System.Runtime.Serialization;
using System.Web;

namespace HomePageVST.Extensions.AntiModelInjection
{
    [Serializable]
    public sealed class HttpAntiModelInjectionException : HttpException
    {
        public HttpAntiModelInjectionException()
        {
        }

        private HttpAntiModelInjectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpAntiModelInjectionException(string message) : base(message)
        {
        }

        public HttpAntiModelInjectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}