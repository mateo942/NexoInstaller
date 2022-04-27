using CommandLine;
using Nexo.Installer.Command.Cleanup;
using Nexo.Installer.Command.Install;
using Nexo.Installer.Command.Pack;
using Nexo.Installer.Command.Upload;
using Nexo.Installer.Helpers;
using System;

namespace Nexo.Installer
{
    internal class Program
    {
        private static ILogger _logger;

        static void Main(string[] args)
        {
            _logger = new Logger();

            Parser.Default.ParseArguments<PackOptions, InstallOptions, UploadOptions, CleanupOptions>(args)
                .WithParsed<PackOptions>(options => new PackHandler(options, _logger).Execute())
                .WithParsed<InstallOptions>(options => new InstallHandler(options, _logger).Execute())
                .WithParsed<UploadOptions>(options => new UploadHandler(options, _logger).Execute())
                .WithParsed<CleanupOptions>(options => new CleanupHandler(options, _logger).Execute())
                .WithNotParsed(errors => Environment.Exit(-1));
        }
    }
}
