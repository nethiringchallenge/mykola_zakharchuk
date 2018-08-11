using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talk_to_me
{
    public interface IStrategy
    {
        string GetAnswer(IEnumerable<string> content);
    }
}
