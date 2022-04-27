using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Install
{
    [Verb("install", HelpText = "Instalacja rozwiązania do podmiotu")]
    public class InstallOptions
    {
        [Option('c', Required = true, HelpText = "Połączenie z bazą danych")]
        public string ConnectionString { get; set; }
        [Option('s', Required = true, HelpText = "Spakowane rozwiązanie własne (*.mpkg)")]
        public string Source { get; set; }
        [Option('r', Required = false, HelpText = "Zastąp wszystkie starsze rozwiązania")]
        public bool WithReplace { get; set; }
    }
}
