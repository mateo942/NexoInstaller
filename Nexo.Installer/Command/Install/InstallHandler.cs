using InsERT.Mox.Launcher;
using Nexo.Installer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Install
{
    public class InstallHandler
    {
        private readonly InstallOptions _uploadOptions;
        private readonly ILogger _logger;

        public InstallHandler(InstallOptions uploadOptions, ILogger logger)
        {
            _uploadOptions = uploadOptions;
            _logger = logger;
        }

        public void Execute()
        {
            _logger.Debug($"Połączenie z bazą: {_uploadOptions.ConnectionString}");
            _logger.Debug($"Źródło: {_uploadOptions.Source}");
            _logger.Debug($"Zastąp: {_uploadOptions.WithReplace}");

            SqlDatabase sqldb = new SqlDatabase(_uploadOptions.ConnectionString);
            Package pakiet = new Package(_uploadOptions.Source);
            ArtifactIdentity ident = pakiet.Manifest.Identity;
            DeploymentManifest dm = sqldb.GetDeploymentManifest("Nexo");
            if (!dm.AdditionalPackages.Contains(ident))
            {
                var pacakges = dm.AdditionalPackages;

                if (_uploadOptions.WithReplace)
                {
                    pacakges = pacakges.Where(x => x.Name != ident.Name);
                    _logger.Info("Usuwanie starego rozwiązania");
                }

                _logger.Info("Dodawanie nowego rozwiązania");
                dm = new DeploymentManifest(dm.Product, dm.DeploymentName, pacakges.Concat(new[] { ident }));

                _logger.Info("Zapisywanie");
                sqldb.WriteDeploymentManifest(dm, true);
            } else
            {
                _logger.Info("Rozwiązanie jest już zainstalowane");
            }

            _logger.Info("Zakończono dodawanie rozwiązania");
        }
    }
}
