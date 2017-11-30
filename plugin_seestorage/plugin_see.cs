using Neo.GUIPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plugin_seestorage
{
    public class plugin_see : IPlugin
    {
        public string Name => "SeeStorage";

        public string[] GetMenus()
        {
            return new string[] { "Find", "nothing","nothing2" };
        }
        IAPI api;
        public void Init(IAPI api)
        {
            this.api = api;
        }

        public void OnMenu(string menu)
        {
            if (menu == "Find")
            {
                SeeStorage see = new SeeStorage();
                see.ShowDialog();
            }

        }
    }
}
