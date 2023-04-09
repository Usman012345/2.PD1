
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_task1
{
    class Program
    {
        static int Main(string[] args)
        {
            bool found = false;
            int option, medicine_count = 0, price_count = 0 ;
            string mname;
            int[] price = new int[5];
            string[] medicine=new string[5];
        jump:
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ### ##   ###  ##    ##     ### ##  ##   ##     ##      ## ##  ##  ##             ### ##   ### ###   ## ##    ## ##   ### ##   ### ##");
                Console.WriteLine(" ##  ##   ##  ##     ##     ##  ##   ## ##      ##    ##   ##  ##  ##             ##  ##   ##  ##  ##   ##  ##   ##   ##  ##   ##  ##");
                Console.WriteLine(" ##  ##   ##  ##   ## ##    ##  ##  # ### #   ## ##   ##       ##  ##             ##  ##   ##      ##       ##   ##   ##  ##   ##  ##");
                Console.WriteLine(" ##  ##   ## ###   ##  ##   ## ##   ## # ##   ##  ##  ##        ## ##             ## ##    ## ##   ##       ##   ##   ## ##    ##  ##");
                Console.WriteLine(" ## ##    ##  ##   ## ###   ## ##   ##   ##   ## ###  ##         ##               ## ##    ##      ##       ##   ##   ## ##    ##  ##");
                Console.WriteLine(" ##       ##  ##   ##  ##   ##  ##  ##   ##   ##  ##  ##   ##    ##               ##  ##   ##  ##  ##   ##  ##   ##   ##  ##   ##  ##");
                Console.WriteLine("####     ###  ##  ###  ##  #### ##  ##   ##  ###  ##   ## ##     ##              #### ##  ### ###   ## ##    ## ##   #### ##  ### ## ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Main menu<<Sign in/up<<Admin menu");
                Console.WriteLine("1.Add medicine record..");
                Console.WriteLine("2.Print medicine record..");
                Console.WriteLine("3.Enter prices..");
                Console.WriteLine("4.Remove medicine..");
                Console.WriteLine("0.exit");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Main menu<<Sign in/up<<Admin menu<<Add employee ");
                    Console.WriteLine("Enter medicine name: ");
                    medicine[medicine_count] = Console.ReadLine();
                    medicine_count++;
                }
                if (option == 2)
                {
                    Console.WriteLine("Main menu<<Sign in/up<<Admin menu<<Print medicine record ");
                    for (int x = 0; x < medicine_count; x++)
                    {
                        Console.WriteLine("{0} , Price: {1}",medicine[x],price[x]);
                    }
                }
                if (option == 3)
                {
                    for (int x = price_count; x < medicine_count; x++)
                    {
                        Console.WriteLine("{0} Enter the price: ", medicine[x]);
                        price[x] = int.Parse(Console.ReadLine());
                        price_count++;
                    }
                }
                if (option == 4)
                {
                    Console.WriteLine("Main menu<<Sign in/up<<Admin menu<<Remove medicine ");
                    Console.WriteLine("Enter medicine name: ");
                    mname = Console.ReadLine();
                    for (int x = 0; x < medicine_count; x++)
                    {
                        if (mname == medicine[x])
                        {
                            found = true;
                            medicine[x] = "-1";
                            for (int y = x; y < medicine_count; y++)
                            {
                                medicine[y] = medicine[y + 1];
                            }
                            medicine_count--;
                        }
                    }
                        if(found ==false)
                            Console.WriteLine("The medicine does not exist.");
            
                }
                if (option == 0)
                {
                    return 0;
                }
                else if (new[] { 1, 2, 3, 4 }.All(x => x != option))
                {
                    Console.WriteLine("Wrong input!!!");
                    Console.ReadLine();
                    goto jump;
                }
                Console.ReadKey();
            }
                return 0;
            

        }
    }
}
