using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MinecraftDialogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ConsoleColor> player = new Dictionary<string, ConsoleColor>()
            {
                ["[Server]"] = ConsoleColor.White,
                ["<D3xteR1337>"] = ConsoleColor.Yellow,
                ["<obasraska65>"] = ConsoleColor.Green,
                ["<Huesos>"] = ConsoleColor.Blue,
                ["<sixodo>"] = ConsoleColor.Cyan,
                ["<Nihooyaz>"] = ConsoleColor.Magenta,
                ["<DivaseLight>"] = ConsoleColor.Gray,
                ["<INTHEEND27>"] = ConsoleColor.DarkGreen
            };
            List<string> dialogLines = new List<string>();
            string textFileToParse = "2019-01-23-6.log";
            string[] fileLines = File.ReadAllLines(@"logs\" + textFileToParse, Encoding.Default);

            GetDialogs(fileLines, player, dialogLines);
            PrintToConsole(player, dialogLines);
            PrintToFile(dialogLines);
            Console.ReadKey();
        }

        public static void GetDialogs(string[] fileLines, Dictionary<string, ConsoleColor> player, List<string> dialogLines)   
        {
            foreach (var line in fileLines)                                        
                foreach (var nickname in player.Keys)                              
                    if (line.Contains(nickname))                                   
                        dialogLines.Add(line.Substring(line.IndexOf(nickname)));   
            if (dialogLines.Count == 0)
                throw new Exception("EmptyDialog");

        }

        public static void PrintToConsole(Dictionary<string, ConsoleColor> player, List<string> dialogLines) 
        {
            foreach (var dialogLine in dialogLines)                 
            {
                foreach (var nickname in player.Keys)                 
                    if (dialogLine.Contains(nickname))
                    {
                        Console.ForegroundColor = player[nickname];
                        Console.WriteLine(dialogLine);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
            }
        }

        public static void PrintToFile(List<string> dialogLines) 
        {
            if (dialogLines.Count != 0)
                using (StreamWriter sw = new StreamWriter(@"logs\" + "MineCraftDialogs.txt"))
                    foreach (var dialogLine in dialogLines)
                        sw.WriteLine(dialogLine);
            else
                throw new Exception("EmptyDialog");
        }
    }
}