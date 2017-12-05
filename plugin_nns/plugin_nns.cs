using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo.GUIPlugin;
using Neo;
using Neo.Core;
using Neo.SmartContract;
using Neo.VM;
using System.Windows.Forms;

namespace plugin_nns
{
    public class plugin_nns : IPlugin
    {
        public string Name => "nns插件";

        public string[] GetMenus()
        {
            return new string[] { "注册器", "解析器", "域名转账" };
        }

        public void OnMenu(string menu)
        {
            if (menu == "注册器")
            {
                System.Windows.Forms.MessageBox.Show("请求注册器");
            }
            else if (menu == "解析器")
            {
                //MessageBox.Show("请求解析器");
                nnsResolverAddr nnsResolverAddr = new nnsResolverAddr();
                nnsResolverAddr.ShowDialog();
            }
            else if (menu == "域名转账")
            {
                nnsTransfer nnsTransfer = new nnsTransfer();
                nnsTransfer.ShowDialog();
            }
        }

        public static IAPI api;
        public void Init(IAPI api) => plugin_nns.api = api;
    }
}
