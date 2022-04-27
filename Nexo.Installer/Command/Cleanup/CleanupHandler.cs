using InsERT.Mox.Launcher;
using Nexo.Installer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Cleanup
{
    public class CleanupHandler
    {
        private readonly CleanupOptions _cleanupOptions;
        private readonly ILogger _logger;

        public CleanupHandler(CleanupOptions cleanupOptions, ILogger logger)
        {
            _cleanupOptions = cleanupOptions;
            _logger = logger;
        }

        public void Execute()
        {
            _logger.Debug($"Połączenie z bazą: {_cleanupOptions.ConnectionString}");
            _logger.Debug($"Nazwa: {_cleanupOptions.Name}");
            _logger.Debug($"Maksymalna liczba rozwiązań: {_cleanupOptions.MaxCount}");

            SqlDatabase launchdb = new SqlDatabase(_cleanupOptions.ConnectionString);
            var packages = launchdb.Query(ArtifactQuerySpecification.ByName(_cleanupOptions.Name), PackageQueryScope.Name)
                .OrderBy(x => x.Identity.Version)
                .ToArray();

            _logger.Info($"Pobrano: {packages.Length} rozwiązań");
            for (int i = 0; i < packages.Length; i++)
            {
                _logger.Debug(packages[i].Identity.ToString());
            }

            for (int i = 0; i < packages.Length - _cleanupOptions.MaxCount; i++)
            {
                _logger.Info($"Usuwanie: {packages[i].Identity}");
                launchdb.DeletePackage(packages[i].Identity);
                _logger.Info($"Usunięto");
            }

            _logger.Info($"Zakończono czyszczenie bazy danych");
        }
    }
}
