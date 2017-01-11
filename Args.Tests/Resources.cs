using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Args.Tests.Properties
{
    using System;
    using System.Globalization;

    internal class Resources
    {
        private static CultureInfo resourceCulture;

        internal class ResourceManager
        {
            private static Func<string> HelpOutput = () =>
            {
                return System.IO.File.ReadAllText("Resources/HelpOutput.txt");
            };

            private static Dictionary<string, Func<string>> _resources;

            static ResourceManager()
            {
                _resources = new Dictionary<string, Func<string>>
                {
                    { "HelpOutput", HelpOutput }
                };
            }

            internal static string GetString(string name, CultureInfo culture)
            {
                return _resources[name]();
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to &lt;command&gt; [/Id] [/Name] [/Switch] [/Date] [/Descripton]
        ///
        ///
        ///[/Id|/I]              This is the Id
        ///[/Name|/N]            This is the name you should put in. This is an extremely 
        ///                      long description that should take multiple lines to 
        ///                      output. The formating should still be maintained and 
        ///                      should look good in the output.
        ///[/Switch|/S]          Force it!
        ///[/Date|/Da]           Effective date
        ///[/Descripton|/De]     aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string HelpOutput
        {
            get
            {
                return ResourceManager.GetString("HelpOutput", resourceCulture);
            }
        }
    }
}

