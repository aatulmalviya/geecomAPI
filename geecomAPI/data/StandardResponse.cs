namespace geecomAPI.data
{
    public enum responseStatus
    {
        Success,
        ValidationFailed,
        Failed
    }
    public class standardResponse
    {
        string _status = string.Empty;
        public string Status { get { return _status; } }

        string _message = string.Empty;
        public string Message { get { return _message; } }

        object _val = null;
        public object Value { get { return _val; } }

        public static standardResponse GetInstance(responseStatus status, string message, object val)
        {
            standardResponse objRet = new standardResponse();
            objRet._status = status == responseStatus.Success ? "Success" : "Failed";
            objRet._message = message;
            objRet._val = val;
            return objRet;
        }
    }
}
