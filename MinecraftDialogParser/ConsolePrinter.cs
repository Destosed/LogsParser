using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftDialogParser
{
    class ConsolePrinter : IPrintable
    {
        Random rnd = new Random();
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

        public void print(ChatEntry[] entries)
        {
            foreach(ChatEntry entry in entries)
            {
                if (!player.Keys.Contains(entry.author))
                    player.Add(entry.author, (ConsoleColor)rnd.Next(0, 15));

                Console.ForegroundColor = player[entry.author];
                Console.WriteLine(entry.author + ": " + entry.message);
            }
        }
    }
}
