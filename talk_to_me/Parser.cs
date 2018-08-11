using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talk_to_me
{
    public class Parser
    {
        private List<string> _args;

        public Parser(IEnumerable<string> args)
        {
            if (args != null)
            {
                _args = args.ToList();
            }   
        }

        public bool GetArgValue(string cmd, out string value)
        {
            if (_args == null || string.IsNullOrEmpty(cmd))
            {
                value = string.Empty;
                return false;
            }

            int index = _args.IndexOf(cmd);

            if (index < 0 || _args.Count <= index + 1)
            {
                value = string.Empty;
                return false;
            }

            value = _args[index + 1];

            return true;
        }
    }
}
