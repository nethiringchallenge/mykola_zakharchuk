using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talk_to_me
{
    public class RandomStrategy : IStrategy
    {
        private List<string> _content = null;
        private Random _rnd = new Random();

        public string GetAnswer(IEnumerable<string> content)
        {
            if (_content == null || _content.Count == 0)
            {
                _content = new List<string>(content);
            }

            int count = _content.Count;            
            int lineIndex = _rnd.Next(0, count); // creates a number between 0 and count-1

            string nextAnswer = _content[lineIndex];
            _content.Remove(nextAnswer);

            return nextAnswer;
        }

        public override string ToString()
        {
            return "rand";
        }
    }

    public class DefaultStrategy : IStrategy
    {
        public string GetAnswer(IEnumerable<string> content)
        {
            return "Default Strategy Answer";
        }

        public override string ToString()
        {
            return "none";
        }
    }
}
