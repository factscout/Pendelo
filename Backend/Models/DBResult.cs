namespace Backend.Models
{
    public class DBResult
    {
        public bool success;
        public string error;
        public object? result;


        public DBResult(bool _success, string _error, object _result) {
            success = _success;
            error = _error;
            result = _result;
        }

        public DBResult(bool _success, string _error) {
            success = _success;
            error = _error;

        }

    }
}
