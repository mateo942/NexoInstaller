using CommandLine;

namespace Nexo.Installer.Command.Cleanup
{
    [Verb("cleanup", HelpText = "Czyszczenie baz nexo z rozwiązań własnych")]
    public class CleanupOptions
    {
        [Option('c', Required = true, HelpText = "Połączenie z bazą danych")]
        public string ConnectionString { get; set; }

        [Option('n', Required = true, HelpText = "Nazwa rozwiązania własnego")]
        public string Name { get; set; }

        [Option('m', Required = false, HelpText = "Maksymalna ilość rozwiązań", Default = 5)]
        public int MaxCount { get; set; }
    }
}
