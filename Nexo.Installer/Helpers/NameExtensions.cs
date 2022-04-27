using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexo.Installer.Helpers
{
    public static class NameExtensions
    {
        public static string NormalizeName(this string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));

            return name.Replace(" ", "_");
        }
    }
}
