using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talk_to_me
{
    public static class Helper
    {
        private static IStrategy _default = new DefaultStrategy();

        public static IStrategy ResolveStrategy(eStrategy strategy)
        {
            switch (strategy)
            {
                case eStrategy.rand:
                    return new RandomStrategy();

                case eStrategy.downseq:
                case eStrategy.none:
                case eStrategy.upseq:
                default:
                    return _default;
            }
        }
    }
}
