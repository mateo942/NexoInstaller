using InsERT.Mox.Launcher;
using Nexo.Installer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Command.Upload
{
    public class UploadHandler
    {
        private readonly UploadOptions _uploadOptions;
        private readonly ILogger _logger;

        public UploadHandler(UploadOptions uploadOptions, ILogger logger)
        {
            _uploadOptions = uploadOptions;
            _logger = logger;
        }

        public void Execute()
        {
            _logger.Debug($"Połączenie z bazą: {_uploadOptions.ConnectionString}");
            _logger.Debug($"Źródło: {_uploadOptions.Source}");

            Package pakiet = new Package(_uploadOptions.Source);
            SqlDatabase launchdb = new SqlDatabase(_uploadOptions.ConnectionString);
            _logger.Info($"Wysyłanie pakietu: {pakiet.Manifest.PackageFileName}");
            bool wyslany = launchdb.UploadPackage(pakiet, true);

            if (wyslany)
            {
                _logger.Info("Wysyłanie zakończone powodzeniem");
            } else
            {
                _logger.Info("Wysyłanie zakończone niepowidzeniem");
            }
        }
    }
}
