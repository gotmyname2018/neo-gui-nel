using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo.SmartContract.Debug
{
    public class LogScript
    {
        public LogScript parent;
        public string hash;
        public List<LogOp> ops = new List<LogOp>();
        public LogScript(string hash)
        {
            this.hash = hash;
        }
    }
    public class LogOp
    {
        public int addr;
        public string op;
        public string syscall;
        public string[] syscallinfo;
        public string opresulttype;
        public LogOp(int addr, string op)
        {
            this.addr = addr;
            this.op = op;
        }
        public LogScript subScript;
    }


    public class FullLog
    {
        public LogScript script = null;
        public string error = null;
        public string state = null;

        LogScript curScript = null;
        LogOp curOp = null;
        public void LoadScript(string hash)
        {
            if (script == null)
            {
                script = new LogScript(hash);
                curScript = script;
            }
            else
            {
                curOp.subScript = new LogScript(hash);
                curOp.subScript.parent = curScript;
                curScript = curOp.subScript;
            }
        }
        public void NextOp(int addr, string op)
        {
            LogOp _op = new LogOp(addr, op);
            curScript.ops.Add(_op);
            curOp = _op;
            if (op == "RET" || op == "TAILCALL")
            {
                curScript = curScript.parent;
            }
        }
        public void SysCall(string name)
        {
            curOp.syscall = name;
        }
        public void SysCallInfo(string name, bool result, params string[] args)
        {
            string[] syscallinfo = new string[args.Length + 1];
            syscallinfo[0] = result.ToString();
            Array.Copy(args, 0, syscallinfo, 1,args.Length);
        }
        public void OpResult(string type, string value)
        {
            
        }
        public void Error(string info)
        {
            this.error = info;
        }
        public void Finish(string state)
        {
            this.state = state;
        }
    }
}
