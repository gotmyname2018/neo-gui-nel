﻿using Neo.GUIPlugin;
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
        public string Name => "Profile";

        private static readonly string DEFAULT_CONTRACT_SCRIPT_HASH = "0xcc04726d14cd0af9fdfd6c3d47e53e81c66bbd40";
        public static string ContractScriptHash = DEFAULT_CONTRACT_SCRIPT_HASH;

        public void Init(IAPI api)
        {
            plugin_profile.api = api;
        }

        public string[] GetMenus()
        {
            return new string[] { "Settings", "My profile", "Query account", "Manual verify" };
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
            }
        }
    }
}
