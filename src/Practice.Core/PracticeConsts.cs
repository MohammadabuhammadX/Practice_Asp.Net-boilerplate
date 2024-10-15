using Practice.Debugging;

namespace Practice
{
    public class PracticeConsts
    {
        public const string LocalizationSourceName = "Practice";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "0ab3871ef0694e95b3caf417064fc85a";
    }
}
