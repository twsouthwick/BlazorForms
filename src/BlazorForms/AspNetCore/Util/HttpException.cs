namespace System.Web
{
    internal class HttpException : Exception
    {
        public HttpException(string message)
                    : base(message)
        {
        }
    }
}
