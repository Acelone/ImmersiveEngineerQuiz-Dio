using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immersive_Engineer_Quiz_Exercise_2
{
    class Program
    {
        static void print24(String str)
        {
            int h1 = (int)str[1] - '0';
            int h2 = (int)str[0] - '0';
            int hh = (h2 * 10 + h1 % 10);
            if (str[8] == 'A')
            {
                if (hh == 12)
                {
                    Console.Write("00");
                    for (int i = 2; i <= 7; i++)
                        Console.Write(str[i]);
                }
                else
                {
                    for (int i = 0; i <= 7; i++)
                        Console.Write(str[i]);
                }
            }
            else
            {
                if (hh == 12)
                {
                    Console.Write("12");
                    for (int i = 2; i <= 7; i++)
                        Console.Write(str[i]);
                }
                else
                {
                    hh = hh + 12;
                    Console.Write(hh);
                    for (int i = 2; i <= 7; i++)
                        Console.Write(str[i]);
                }
            }
        }

        public static void Main(String[] args)
        {
            Console.Write("Input Time (HH:mm:ss(PM/AM)\n");
            String str = Console.ReadLine();
            print24(str);
            Console.Write("\nPress Enter to continue...\n");
            String end = Console.ReadLine();
        }
    }
}
