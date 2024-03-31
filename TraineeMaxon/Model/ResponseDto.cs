using System.Net;

namespace TraineeMaxon.Model
{
    public class ResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Result { get; set; } = default!;

    }
}
