using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talk_to_me.Properties;

namespace talk_to_me
{
    class Program
    {
        

        static void Main(string[] args)
        {
            if (args == null || args.Length != 4)
            {
                Console.WriteLine(Resources.WrongArgs);
                return;
            }

            Parser parser = new Parser(args);
        
            string strategy = string.Empty;
            string filePath = string.Empty;
            eStrategy eStrategy = eStrategy.none;

            if (!parser.GetArgValue("-r", out strategy) && !Enum.TryParse(strategy.ToLower(), out eStrategy))
            {
                Console.WriteLine(Resources.BadStrategy);
                return;
            }
            
            if (!parser.GetArgValue("-f", out filePath) || string.IsNullOrEmpty(filePath) || !File.Exists(Path.GetFullPath(filePath)))
            {
                string path = Path.GetFullPath(filePath).Replace("\\", "\\");
                if (!File.Exists(path))
                {
                    Console.WriteLine(Resources.BadFile);
                    return;
                }
            }

            filePath = Path.GetFullPath(filePath);
            string[] content = File.ReadAllLines(filePath);

            IStrategy answerStrategy = Helper.ResolveStrategy(eStrategy);
            if (answerStrategy == null)
            {
                Console.WriteLine(Resources.NoStrategy);
                return;
            }

            ChatBot bot = new ChatBot(content, answerStrategy, Helper.ResolveStrategy);

            while (true)
            {
                Console.WriteLine(bot.Run(Console.ReadLine()));
            }
        }

       
    }
}
