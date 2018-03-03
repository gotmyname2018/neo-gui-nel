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
        public string Name => "Profile";

        public void Init(IAPI api)
        {
            plugin_profile.api = api;
        }

        public string[] GetMenus()
        {
            return new string[] { "Profile" };
        }
        
        public void OnMenu(string menu)
        {
            if (menu == "Profile")
            {
                ProfileForm form = new ProfileForm();
                form.ShowDialog();
            }
        }
    }
}
