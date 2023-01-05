using System;
using Warre_Gehre_GameDevelopment.GameFiles;

namespace Warre_Gehre_GameDevelopment.GameFiles
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}


