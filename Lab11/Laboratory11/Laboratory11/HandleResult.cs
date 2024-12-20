namespace Laboratory11
{
    public struct HandleResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } // generic

        public HandleResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}