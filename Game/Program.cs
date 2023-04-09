using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using EZInput;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            Console.Write("1.Play");
            Console.WriteLine(" ");
            Console.WriteLine("2.Instructions");
            option = int.Parse(Console.ReadLine());
            if (option == 1)
                play();
        }
              static void play()
        {   
                int x = 10;
                int y = 10;
                maze();
                player(x, y);

        }
        static void maze()
        {
            string[] maze = {
   "##################################################################################################################",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "#                                                                                                                #",
   "##################################################################################################################"
};
            for (int row = 0; row < 35; row++)
            {
                for (int column = 0; column < 114; column++)
               Console.Write(maze[row][column]);
                Console.WriteLine();
            }
        }

        static void player(int x,int y)
        {
            player_char(x, y);
            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveup(ref x,ref y);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    movedown( ref x, ref y);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveleft(ref x, ref y);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveright(ref x, ref y);
                }
                if(Keyboard.IsKeyPressed(Key.Space))
                {
                    bullet(x,y);
                }
            }
        }
        static void bullet(int x,int y)
        {
         
            char n=GetCharAtXY(x, y);
            int c = x;
            while (n == ' ')
            {
                Console.SetCursorPosition(c, y);
                Console.WriteLine(".");
                c++;
            }
        }
        static void  moveup(ref int x, ref int y)
        {
            char[,] v = new char[x, y];
            char n = getCharAtxy(x, y - 1);
            /*   Console.WriteLine(n);*/
            GetCharAtXY(x, y);


            Console.SetCursorPosition(x, y+1);
             Console.WriteLine("  ");
            if(y>0)
            y -=1;
            player_char(x, y);
            Thread.Sleep(100);
        }
        static void player_char( int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" .");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("||");
        }
      static void movedown(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  ");
            if(y<30)
            y += 1;
            player_char(x, y);
            Thread.Sleep(100);
        }
        static void moveright(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  ");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine(" ");
            if(x<120)
            x += 1;
            player_char(x, y);
            Thread.Sleep(100);
        }
        static void moveleft(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  ");
            Console.SetCursorPosition(x+1, y+1);
            Console.WriteLine(" ");
            if(x>0)
            x -= 1;
            player_char(x, y);
            Thread.Sleep(100);
        }
        class ConsoleUtils
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool ReadConsoleOutput(
                IntPtr hConsoleOutput,
                out CHAR_INFO lpBuffer,
                COORD dwBufferSize,
                COORD dwBufferCoord,
                ref SMALL_RECT lpReadRegion);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetStdHandle(int nStdHandle);

            [StructLayout(LayoutKind.Explicit)]
            struct CHAR_INFO
            {
                [FieldOffset(0)]
                public char UnicodeChar;
                [FieldOffset(0)]
                public byte AsciiChar;
                [FieldOffset(2)]
                public short Attributes;
            }

            [StructLayout(LayoutKind.Sequential)]
            struct COORD
            {
                public short X;
                public short Y;

                public COORD(short x, short y)
                {
                    this.X = x;
                    this.Y = y;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            struct SMALL_RECT
            {
                public short Left;
                public short Top;
                public short Right;
                public short Bottom;

                public SMALL_RECT(short left, short top, short right, short bottom)
                {
                    this.Left = left;
                    this.Top = top;
                    this.Right = right;
                    this.Bottom = bottom;
                }
                public static char GetCharAtXY(short x, short y)
                {
                    CHAR_INFO ci;
                    COORD xy = new COORD(0, 0);
                    SMALL_RECT rect = new SMALL_RECT(x, y, x, y);
                    COORD coordBufSize = new COORD(1, 1);
                    return ReadConsoleOutput(GetStdHandle(-11), out ci, coordBufSize, xy, ref rect) ? ci.Char.AsciiChar : ' ';
                }
            }
        }
    }
}
