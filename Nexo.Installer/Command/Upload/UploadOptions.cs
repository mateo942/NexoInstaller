using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Upload
{
    [Verb("upload", HelpText = "Upload rozwiązania do bazy")]
    public class UploadOptions
    {
        [Option('c', Required = true, HelpText = "Połączenie z bazą danych")]
        public string ConnectionString { get; set; }
        [Option('s', Required = true, HelpText = "Spakowane rozwiązanie własne (*.mpkg)")]
        public string Source { get; set; }
    }
}
