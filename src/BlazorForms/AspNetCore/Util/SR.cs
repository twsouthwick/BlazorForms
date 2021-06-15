using System;
using System.Collections.Generic;
using System.Text;

namespace System.Web
{
    internal static partial class SR
    {
        public static string GetString(string input)
            => input;

        public static string GetString(string input, params object[] p)
            => input;

        public static string GetString(string input, string arg0)
            => input;

        public const string Path_must_be_rooted = "Path must be rooted";

        public const string Physical_path_not_allowed = "Physical_path_not_allowed";

        public const string Invalid_vpath = "Invalid_vpath";

        public const string Cannot_exit_up_top_directory = "Cannot_exit_up_top_directory";

        public const string HTMLTextWriterUnbalancedPop = "HTMLTextWriterUnbalancedPop";

        public const string Empty_path_has_no_directory = "Empty_path_has_no_directory";

        public const string Style_RegisteredStylesAreReadOnly = "Style_RegisteredStylesAreReadOnly";

        public const string Style_InvalidBorderWidth = "Style_InvalidBorderWidth";

        public const string UnitParseNoDigits = "UnitParseNoDigits";

        public const string UnitParseNumericPart = "UnitParseNumericPart";

        public const string Style_InvalidWidth = "Style_InvalidWidth";

        public const string Style_InvalidHeight = "Style_InvalidHeight";
    }
}
