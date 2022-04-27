using InsERT.Mox.Launcher;
using Nexo.Installer.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Pack
{
    public class PackHandler
    {
        private readonly PackOptions _packOptions;
        private readonly ILogger _logger;

        public PackHandler(PackOptions packOptions, ILogger logger)
        {
            _packOptions = packOptions;
            _logger = logger;
        }

        public void Execute()
        {
            _logger.Debug($"Źródło: {_packOptions.SourceDirectory}");
            _logger.Debug($"Wersja: {_packOptions.Version}");
            _logger.Debug($"Nazwa: {_packOptions.Name}");
            _logger.Debug($"Wyklucz plik: {string.Join(", ", _packOptions.ExcludedPatterns)}");

            var packageName = $"{_packOptions.Name.NormalizeName()}-{_packOptions.Version}";
            _logger.Info($"Nazwa rozszerzenia: {packageName}");

            var sourceManifestPath = Path.Combine(_packOptions.SourceDirectory, "source.manifest.xml");
            if (!File.Exists(sourceManifestPath))
            {
                _logger.Info("Tworzenie pliku konfiguracyjnego");
                StringBuilder appManifest = new StringBuilder();
                appManifest.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                appManifest.AppendLine($"<Package Identity=\"{packageName}\" DisplayName=\"\" VersionDisplayName=\"\">");
                appManifest.AppendLine("<Contents />");
                appManifest.AppendLine("<LaunchScenarios />");
                appManifest.AppendLine("<DeployActions />");
                appManifest.AppendLine("<Dependencies />");
                appManifest.Append("</Package>");

                string manifest = appManifest.ToString();
                _logger.Debug(manifest);
                File.WriteAllText(sourceManifestPath, manifest);
                _logger.Info("Zapisanie pliku konfiguracyjnego");
            }

            _logger.Info("Zapisywanie paczki...");
            Package.Create(_packOptions.SourceDirectory, _packOptions.Version, null, _packOptions.ExcludedPatterns);
            _logger.Info($"Utworzenie paczki: {packageName}.mpkg");
        }
    }
}
