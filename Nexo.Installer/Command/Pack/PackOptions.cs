using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Pack
{
    [Verb("pack", HelpText = "Spakuj rozwiązanie włąsne")]
    public class PackOptions
    {
        [Option('s', Required = true, HelpText = "Folder zawierający pliki rozwiązania")]
        public string SourceDirectory { get; set; }

        [Option('v', Required = true, HelpText = "Wersja rozwiązania")]
        public Version Version { get; set; }

        [Option('n', Required = true, HelpText = "Nazwa rozwiązania")]
        public string Name { get; set; }

        [Option('e', Required = false, HelpText = "Schamaty wykluczonych plików", Separator = ';', Default = new string[0])]
        public IEnumerable<string> ExcludedPatterns { get; set; }
    }
}
