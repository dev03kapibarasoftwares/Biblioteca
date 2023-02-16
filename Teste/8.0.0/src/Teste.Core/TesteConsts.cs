using Teste.Debugging;

namespace Teste
{
    public class TesteConsts
    {
        public const string LocalizationSourceName = "Teste";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "b5c64622d4e34f8d8072691422c567ab";
    }
}
