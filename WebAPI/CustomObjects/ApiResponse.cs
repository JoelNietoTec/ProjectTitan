using Newtonsoft.Json;

namespace WebAPI.CustomObjects
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }
        private static string GetDefaultMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Recurso no disponible";
                case 500:
                    return "Error desconocido, consulte soporte técnico";
                default:
                    return null;
            }
        }
    }
}