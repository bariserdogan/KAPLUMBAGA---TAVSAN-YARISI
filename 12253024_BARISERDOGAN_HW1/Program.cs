using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace _12253024_BARISERDOGAN_HW1
{
    class Program
    {
        static int kaplumbaga_x = 0; // kaplumbağanın konumu için
        static int tavsan_x = 0; // tavşanın konumu için

        public static void Main(string[] args)
        {
            // timer kullanarak saniyede bir  metodumuzu çağırıyoruz

            Timer t = new Timer(1000); // (1000 --> 1sn , 2000 --> 2sn vs...)
            t.Elapsed += new ElapsedEventHandler(race);
            t.Start(); // timer başladı

            while (true) // timer ' ın devam etmesi için
            {

            }
        }
        static void race(object o, ElapsedEventArgs a)
        {

            Random rand = new Random();
            int kaplumbaga_adim = rand.Next(1, 11);
            kaplumbaga_x += kaplumbaga_adim; 
            int tavsan_adim = rand.Next(1, 11);
            tavsan_x += tavsan_adim;

            /* Kaplumbağa Hareket Kontrolleri */
            /*--------------------------------------------*/

            if (kaplumbaga_x >= 1 && kaplumbaga_x <= 5)
                kaplumbaga_x += 3;
            else if (kaplumbaga_x >= 6 && kaplumbaga_x <= 7)
            {
                if (kaplumbaga_x >= kaplumbaga_adim)
                {
                    kaplumbaga_x -= 6;
                }
                else
                    kaplumbaga_x = 1;
            }
            else
                kaplumbaga_x++;

            /* Tavşan Hareket Kontrolleri */
            /*-------------------------------------*/

            if (tavsan_x >= 1 && tavsan_x <= 2)
            {
                // hareketsiz kal
            }
            else if (tavsan_x >= 3 && tavsan_x <= 4)
                tavsan_x += 9;
            else if (tavsan_x == 5)
            {
                if (tavsan_x >= tavsan_adim)
                {
                    tavsan_x -= 12;
                }
                else
                    tavsan_x = 1;
            }
            else if (tavsan_x >= 6 && tavsan_x <= 8)
                tavsan_x++;
            else
            {
                if (tavsan_x >= tavsan_adim)
                {
                    tavsan_x -= 2;
                }
                else
                {
                    tavsan_x = 1;
                }
            }



            //Console.Clear();
            for (int i = 0; i < 70; i++)
            {
                if (kaplumbaga_x == tavsan_x && kaplumbaga_x == i)
                {
                    Console.Write("OUCH");
                }
                else if (kaplumbaga_x == i)
                {
                    Console.Write("K");
                }
                else
                {
                    Console.Write('-');
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 70; i++)
            {
                if (kaplumbaga_x == tavsan_x && tavsan_x == i)
                {
                    Console.Write("OUCH");
                }
                else if (tavsan_x == i)
                {
                    Console.Write("T");
                }
                else
                {
                    Console.Write('-');
                }
            }

            Console.WriteLine();
            if (kaplumbaga_x >= 70 && tavsan_x >= 70)
            {
                Console.WriteLine("BERABERE");
                Environment.Exit(0); //berabere bittiğinde yarışı sonlandır
                return;
            }
            else if (kaplumbaga_x >= 70)
            {

                Console.WriteLine("KAPLUMBAĞA KAZANDI!!!OLEY!!!");
                Environment.Exit(0); //kaplumbağa kazandığında yarışı sonlandır 
                return;
            }

            else if (tavsan_x >= 70)
            {
                Console.WriteLine("TAVŞAN KAZANDI.YUH!!!");
                Environment.Exit(0); //tavşan kazandığında yarışı sonlandır
                return;
            }
        }

    }
}
