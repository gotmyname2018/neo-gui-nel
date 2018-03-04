using Neo.GUIPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plugin_profile
{
    public class plugin_profile : IPlugin
    {
        public static IAPI api;
        public string Name => "Account profile";

        public static string ContractScriptHash;

        public void Init(IAPI api)
        {
            plugin_profile.api = api;
            plugin_profile.ContractScriptHash = api.GetConfig("ProfileContractScriptHash");
        }

        public string[] GetMenus()
        {
            return new string[] { "Settings", "My profile", "Query account", "Manual verify", "Manual grant (testing only)" };
        }
        
        public void OnMenu(string menu)
        {
            switch (menu)
            {
                case "Settings":
                    ProfileSettingsForm form1 = new ProfileSettingsForm();
                    form1.ShowDialog();
                    break;
                case "My profile":
                    MyProfileForm form2 = new MyProfileForm();
                    form2.ShowDialog();
                    break;
                case "Query account":
                    QueryAccountForm form3 = new QueryAccountForm();
                    form3.ShowDialog();
                    break;
                case "Manual verify":
                    ManualVerifyForm form4 = new ManualVerifyForm();
                    form4.ShowDialog();
                    break;
                case "Manual grant (testing only)":
                    ManualGrantForm form5 = new ManualGrantForm();
                    form5.ShowDialog();
                    break;
            }
        }
    }
}
