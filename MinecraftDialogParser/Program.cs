using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MinecraftDialogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dialogLines = new List<string>();
            string textFileToParse = "2019-01-23-5.log";
            string[] fileLines = File.ReadAllLines(@"logs/" + textFileToParse, Encoding.Default);
            ChatEntry[] chatEntries = parseLog(fileLines);

            if(chatEntries.Length > 0)
            {
                IPrintable printable = new ConsolePrinter();
                printable.print(chatEntries);
            }
            else
            {
                Console.WriteLine("Dialogs are empty");
            }
            
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

        public static ChatEntry[] parseLog(string[] lines)
        {
            Regex regex = new Regex(@"^.*?(\[Server\]|<[A-z0-9\s]+>)\s(.*)");
            List<ChatEntry> list = new List<ChatEntry>();
            foreach(string line in lines)
            {
                Match match = regex.Match(line);
                if(match.Success)
                    list.Add(new ChatEntry(match.Groups[1].Value, match.Groups[2].Value));
            }

            return list.ToArray();
        }
    }
}