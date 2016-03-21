using System;
using CommandLine;
using CommandLine.Text;
using System.Reflection;

namespace ConsoleApplicationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Assembly.GetExecutingAssembly().GetName().FullName;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();

            Console.SetWindowSize(90, 90);
            Console.SetBufferSize(90, 90);

            #region Read keyboard input
            /*
            do
            {
                while (!Console.KeyAvailable)
                {
                    //do nothing
                }

                var k = Console.ReadKey(true);
                Console.WriteLine(k.KeyChar);

                switch (k.Key)
                {
                    case ConsoleKey.B :
                        Console.WriteLine("B pressed");
                        break;
                    case ConsoleKey.UpArrow :
                        Console.WriteLine("Up arrow pressed");
                        break;
                }

            } while (true);
            */
            #endregion
            
            #region Read from file
            /*
            var inputFileName = Path.Combine(Environment.CurrentDirectory, "names.txt");
            //derives from TextReader
            var inputNames = new StreamReader(inputFileName);

            Console.SetIn(inputNames);

            string currentName = Console.ReadLine();
            while (currentName != null)
            {
                Console.WriteLine("Read from file: " + currentName);
                currentName = Console.ReadLine();
            }

            Console.WriteLine("Press enter to continue");
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.ReadLine();
            */
            #endregion

            #region Parsing arguments

            var options = new MyOptions();
            
            //for some reason verb options don't work with help or required
            //Parser.Default.ParseArgumentsStrict(args, options, OnVerbCommand, OnFail);
            
            Parser.Default.ParseArgumentsStrict(args, options, OnFail);

            for (int i = 0; i < options.Times; i++)
            {
                Console.WriteLine("Message (-m): {0}", options.Message);    
            }
            
            Console.Read();

            #endregion
        }

        private static void OnVerbCommand(string verbName, object verbSubOptions)
        {
            // opt 1
            if (verbSubOptions is MixVerbSubOptions)
            {

            }

            // opt 2
            switch(verbName)
            {
                case "mix":
                    var mixSubOptions = (MixVerbSubOptions)verbSubOptions;
                    break;
            }
        }

        private static void OnFail()
        {
            Console.ReadLine();
            Environment.Exit(-1);
        }


    }

    public class MyOptions
    {
        [Option('m', "message", DefaultValue="test message")]
        public string Message { get; set; }
        [Option('t', "times", Required=true, HelpText="Times requires int")]
        public int Times { get; set; }
                
        [OptionArray('n', "names", DefaultValue = new string[] { "noNameSpecified" })]
        public string[] Names { get; set; }

        //verb style arguments like git push, or git commit
        //1 verb style args per execution
        [VerbOption("mix")]        
        public MixVerbSubOptions MixVerb { get; set; }

        [ParserState]
        public IParserState ParserState { get; set; }

        //[HelpOption]
        //public string GetUsege()
        //{
        //    //return HelpText.AutoBuild(this);

        //    var h = new HelpText
        //    {
        //        Copyright = new CopyrightInfo("Bartosz", 2016),
        //        Heading = "Console application demo",
        //        AddDashesToOption = true
        //    };

        //    h.AddOptions(this);

        //    return h;
        //}
    }
}
