using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Thread.PL.Pages.Resources
{
    public class ClientSettingsVisuals
    {
        private static readonly Lazy<ClientSettingsVisuals> _instance = new Lazy<ClientSettingsVisuals>(() => new ClientSettingsVisuals());
        private ClientSettingsVisuals() { }
        public static ClientSettingsVisuals Instance => _instance.Value;

        // Default value for language: "English"
        public string SelectedLanguage { get; set; } = "English";
        public string SelectedTheme { get; set; }  = "Light";
    }
}
