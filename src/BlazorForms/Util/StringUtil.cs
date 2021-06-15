namespace System.Web
{
    internal static class StringUtil
    {
        internal static bool StringStartsWithIgnoreCase(string virtualPath1, string virtualPath2)
        {
            return virtualPath1.StartsWith(virtualPath2, StringComparison.OrdinalIgnoreCase);
        }

        internal static bool EqualsIgnoreCase(string path, int v1, string subpath, int v2, int lPath)
        {
            throw new NotImplementedException();
        }

        internal static bool StringStartsWith(string url, string v)
        {
            throw new NotImplementedException();
        }

        internal static bool StringStartsWith(string url, char v)
        {
            throw new NotImplementedException();
        }

        internal static bool StringEndsWith(string url, char v)
        {
            throw new NotImplementedException();
        }
    }
}
