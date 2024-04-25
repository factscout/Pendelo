using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    public class Responses
    {

        public async static void JsonOk(HttpResponse r, object _value) {
            r.StatusCode = StatusCodes.Status200OK;
            await r.WriteAsJsonAsync(_value);
        }

        public async static void ValidationError(HttpResponse r, string _msg, Dictionary<string, string> _errors) {
            r.StatusCode = StatusCodes.Status422UnprocessableEntity;
            await r.WriteAsJsonAsync(new ValidationError(_msg, _errors));
        }

        public async static void InternalServerError(HttpResponse r) {
            r.StatusCode = StatusCodes.Status500InternalServerError;
            await r.WriteAsync("Internale Server Error");
        }

        public async static void Unauthorized(HttpResponse r, string _msg) {
            r.StatusCode = StatusCodes.Status401Unauthorized;
            await r.WriteAsync(_msg);
        }

    }

    public class ValidationError
    {
        [Required] public string Message { get; set; }
        [Required] public Dictionary<string, string> Errors { get; set; }

        public ValidationError(string message, Dictionary<string, string> errors) {
            Message = message;
            Errors = errors;
        }
    }
}
