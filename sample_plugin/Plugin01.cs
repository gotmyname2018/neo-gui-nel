using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo.GUIPlugin;

namespace plugin_sample
{
    public class Plugin01 : Neo.GUIPlugin.IPlugin
    {
        public string Name => "SamplePlugin";

        public string[] GetMenus()
        {
            return new string[] { "menu1", "menu2" };
        }
        IAPI api;
        public void Init(IAPI api)
        {
            this.api = api;
        }

        public void OnMenu(string menu)
        {
            if(menu == "menu1")
            {
                System.Windows.Forms.MessageBox.Show("you press menu1");
            }
            else if(menu=="menu2")
            {
                System.Windows.Forms.MessageBox.Show("you press menu2");

            }
        }
    }
}
