using CommandLine;
using System;
using System.Collections.Generic;

namespace Nexo.Installer.Command.Pack
{
    [Verb("pack", HelpText = "Spakuj rozwiązanie własne")]
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
