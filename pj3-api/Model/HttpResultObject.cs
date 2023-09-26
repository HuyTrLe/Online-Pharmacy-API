using System.Net;

namespace pj3_api.Model
{
    public class HttpResultObject
    {
        public dynamic Status { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public dynamic Data { get; set; }
    }
}
