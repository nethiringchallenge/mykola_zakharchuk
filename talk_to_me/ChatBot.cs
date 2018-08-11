using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talk_to_me.Properties;

namespace talk_to_me
{
    public class ChatBot
    {
        private const string strategy_cmd = "strategy:";

        private IStrategy _answerStrategy = null;
        private Func<eStrategy, IStrategy> _strategyResolver;
        private IEnumerable<string> _content;

        public ChatBot(IEnumerable<string> content, IStrategy strategy, Func<eStrategy, IStrategy> strategyResolver)
        {
            _answerStrategy = strategy;
            _strategyResolver = strategyResolver;
            _content = content;
        }

        public string Run(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Resources.BadInput;
            }

            if (input.ToLower().StartsWith(strategy_cmd))
            {
                string strategy = input.ToLower().Replace(strategy_cmd, "").Trim();

                eStrategy strategyEnum = eStrategy.none;

                if (_strategyResolver != null && Enum.TryParse(strategy, out strategyEnum))
                {
                    _answerStrategy = _strategyResolver(strategyEnum);
                    return Resources.AnswerStrategy + " " + strategyEnum.ToString();
                }

            }

            else if (_strategyResolver != null)
            {
                return _answerStrategy.GetAnswer(_content);
            }

            return Resources.Error;
        }
    }
}
